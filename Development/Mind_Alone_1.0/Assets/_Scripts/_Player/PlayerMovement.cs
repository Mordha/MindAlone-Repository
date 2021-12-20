using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public bool canMove;
    
    private bool facingRight;
    [SerializeField] private bool hasGun;
    
    public GameObject shootingPoint;
    

 
    private void Start()
    {
        canMove = true;
        facingRight = true;
        hasGun = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            return;
        }
        var distance = speed * Time.deltaTime;
        var horizontal = Input.GetAxis("Horizontal");

        
            if (hasGun && Input.GetButton("Fire1"))
            {
                canMove = false;
            }
            else
            {
                canMove = true;
            }
        
            if (canMove) 
            {
                transform.Translate(/*speed*/ distance * horizontal, 0, 0);
            }

            if (horizontal > 0 && !facingRight)
            {
                Flip();
            }
            else if (horizontal < 0 && facingRight)
            {
                Flip();
            }    
        
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;       
    }
}
