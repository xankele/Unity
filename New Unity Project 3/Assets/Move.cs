using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    public float start = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(start == 0)
        {
            if(transform.position.x > 10f)
            {
                start = 1;
            }
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            if(transform.position.x < 0f)
            {
                start = 0;
            }
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        
    }
}

