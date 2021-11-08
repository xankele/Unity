using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesController : MonoBehaviour
{
    public Rigidbody2D rbPlayer;
    // Start is called before the first frame update

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Cokolwiek");
            rbPlayer.transform.position = new Vector2(-10.0f, -2.0f);
        }
        
    }
}
