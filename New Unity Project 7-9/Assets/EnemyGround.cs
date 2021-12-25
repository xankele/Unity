using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGround : MonoBehaviour
{
    public Transform start;
    public Transform end;
    private Rigidbody2D rb;
    public float speed = 5f;
    public GameObject player;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = Mathf.Abs(transform.position.x - player.transform.position.x);
        if (dist <= 10f)
        {
            if (transform.position.x < player.transform.position.x)
                speed = Mathf.Abs(speed);
            else
                speed = -Mathf.Abs(speed);
        }
        else
        {
            if (transform.position.x < start.position.x)
                speed = Mathf.Abs(speed);
            else if (transform.position.x > end.position.x)
                speed = -Mathf.Abs(speed);
        }
        animator.SetFloat("speed", Mathf.Abs(speed));
        if(speed < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else
            transform.eulerAngles = Vector3.zero;
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}
