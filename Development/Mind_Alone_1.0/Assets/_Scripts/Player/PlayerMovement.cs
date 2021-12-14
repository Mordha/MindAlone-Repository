using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Range(0, .5f)] private float speed;

    [SerializeField] private bool canMove;

    private void Start()
    {
        speed = 0.014f;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = speed * Time.deltaTime;
        var horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Q))
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
        
        if (canMove) 
        {
            transform.Translate(speed * horizontal, 0, 0);
        }
    }
}
