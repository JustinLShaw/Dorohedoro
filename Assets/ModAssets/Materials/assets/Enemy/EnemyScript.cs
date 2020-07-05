using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float move_speed = 2.0f;
    public float animation_diff = 0.5f;
    public float damage_distance = 0.7f;
    public Sprite image1 = null;
    public Sprite image2 = null;
    public GameObject target = null;
    public GameObject mushroom_death = null;
    
    Health m_PlayerHealth;

    public SpriteRenderer sr = null;
    float last_time = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCharacterController playerCharacterController = GameObject.FindObjectOfType<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, PlayerHealthBar>(playerCharacterController, this);

        m_PlayerHealth = playerCharacterController.GetComponent<Health>();

        target = GameObject.Find("Player");
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        float cur_time = Time.time;
        if(cur_time - last_time > animation_diff)
        {
            if(sr.sprite == image1)
            {
                sr.sprite = image2;
            }
            else
            {
                sr.sprite = image1;
            }
            last_time = cur_time;
        }

        //don't change y
        if (Vector3.Distance(this.transform.position, target.transform.position) < 25.0f)
        {
            float save_y = this.transform.position.y;
            this.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, move_speed * Time.deltaTime);
            this.transform.position = new Vector3(this.transform.position.x, save_y, this.transform.position.z);

            this.transform.LookAt(target.transform);
        }

        if (Vector3.Distance(this.transform.position, target.transform.position) < damage_distance) {
            m_PlayerHealth.currentHealth -= 0.5f;
        }

        if(m_PlayerHealth.currentHealth <= 0){
            m_PlayerHealth.Kill();
        }


        //check for damage
        /*
        if (Input.GetMouseButton(0))
        {
            if(Vector3.Distance(this.transform.position, target.transform.position) < damage_distance)
            {
                //spawn mushrooms
                Instantiate(mushroom_death, this.transform);

                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY| RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

                //kill this
                Destroy(sr);
                Destroy(this.GetComponent<BoxCollider>());
                Destroy(this, 5.0f);
            }
        }
        */
    }

}
