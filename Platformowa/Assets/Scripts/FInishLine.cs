using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FInishLine : MonoBehaviour
{   
    GameManager gm;
    void Start()
    {
        gm = GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gm.SwitchState(State.LevelCompleted);
        }

    }
}
