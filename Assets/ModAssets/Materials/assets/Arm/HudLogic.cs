using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HudLogic : MonoBehaviour
{
    public GameObject arm;
    RectTransform arm_rt;

    public float arm_rotate_speed = 1.0f;
    public float arm_rotate_radius = 10.0f;
    float arm_angle = 0.0f;

    public GameObject smoke = null;

    // Start is called before the first frame update
    void Start()
    {
        arm_rt = arm.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.S)
            )
        {
            arm_angle += arm_rotate_speed * Time.deltaTime;
            var offset = new Vector3(Mathf.Sin(arm_angle), Mathf.Cos(arm_angle), 0.0f) * arm_rotate_radius;
            arm_rt.localPosition += offset;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //spawn smoke
            GameObject smoke_go = Instantiate(smoke);
            smoke_go.transform.parent = this.transform;
            smoke_go.GetComponent<RectTransform>().localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            smoke_go.transform.localScale = new Vector3(1480.0f, 700.0f, 1.0f);
            //UnityEngine.Debug.Break();

            EnemyScript[] enemies = FindObjectsOfType<EnemyScript>(); // Change here

            foreach(EnemyScript e in enemies)
            {
                GameObject eo = e.gameObject;
                if (Vector3.Distance(eo.transform.position, e.target.transform.position) < e.damage_distance)
                {
                    //spawn mushrooms
                    GameObject mushroom_death = Instantiate(e.mushroom_death);
                    mushroom_death.transform.parent = this.transform;
                    mushroom_death.transform.localScale = new Vector3(5.0f, 5.0f, 1.0f);
                    //e.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

                    //kill this
                    //Destroy(e.sr);
                    //Destroy(e.GetComponent<BoxCollider>());
                    Destroy(eo);
                }
            }
        }

    }
}
