﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FInishLine : MonoBehaviour
{   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<GameManager>().SwitchState(State.LevelCompleted);

        }
    }
}
