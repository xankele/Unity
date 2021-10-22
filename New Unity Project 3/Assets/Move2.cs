using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody rb;
    public float start = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start == 0)
        {
            if (transform.position.x > 10f)
            {
                start = 1;
                transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
            }
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if(start == 1)
        {
            if (transform.position.z > 10f)
            {
                start = 2;
                transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
            }
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
        else if (start == 2)
        {
            if (transform.position.x < 0f)
            {
                start = 3;
                transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
            }
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else if (start == 3)
        {
            if (transform.position.z < 0f)
            {
                start = 0;
                transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
            }
            transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
        }


    }

}