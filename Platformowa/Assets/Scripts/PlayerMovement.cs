using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask _groundLayer;
    private Rigidbody2D _rb;
    private BoxCollider2D _boxCollider;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, _rb.velocity.y);

        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < 0.01f)
        {
            transform.localScale = new Vector3(-1 , 1, 1);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, speed*2);
            audio.Play();
        }
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0, Vector2.down, 0.1f, _groundLayer);
        return raycastHit.collider != null;
    }
}
