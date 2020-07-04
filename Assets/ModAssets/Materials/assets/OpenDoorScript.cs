using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    public GameObject target = null;
    bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.transform.position, this.transform.position) < 5.0f)
        {
            open = true;
        }
        if(open)
        {
            this.transform.position += Vector3.up * 0.01f;
        }
    }
}
