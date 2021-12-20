using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 10f;

    public bool canMove;

    public bool hasGun;
    
    private float distance;
    
    public Rigidbody2D _rb;

    public static bool aim;

    private float movX;

    public bool facing = true;

    public bool isTalking;
    
    //dashing
  public int direction;
  public float dashingTime;
  public bool isDashing;
  public float dashSpeed;
  private float newSpeed;
  public float initialDashingTime;
  
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        hasGun = false;
        isDashing = false;
        isTalking = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isTalking)
        {
            _rb.velocity = Vector2.zero;
            return;
        }
        if (!canMove)
        {
            return;
        }
        
        movX = Input.GetAxisRaw("Horizontal");

        if (canMove)
        {
            if (movX > 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                facing = true;

            } else if (movX < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                facing = false;

            }    
        }

        if (facing == true)
        {
            direction = 1;
        }
        else if (facing == false)
        {
            direction = -1;
        }

        if (Input.GetButton("Fire1") && hasGun)
        {
            aim = true;
        }
        else
        {
            aim = false;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            isDashing = true;
        }

        if (isDashing)
        {
            dashingTime -= Time.deltaTime;
            newSpeed = dashSpeed + speed;
           // GetComponent<CapsuleCollider2D>().enabled = false;
           // GetComponent<Rigidbody2D>().gravityScale = 0;
            Physics2D.IgnoreLayerCollision(3, 6);
            if (dashingTime <= 0)
            {
                isDashing = false;
                dashingTime = initialDashingTime;
                //GetComponent<CapsuleCollider2D>().enabled = true;
             //   GetComponent<Rigidbody2D>().gravityScale = 1;
                Physics2D.IgnoreLayerCollision(3, 6, false);
            }
        }
    }
    
    private void FixedUpdate()
    {
        if (canMove && !aim && !isTalking)
        {
            Vector2 movement = new Vector2(movX * speed, _rb.velocity.y);
            _rb.velocity = movement;
            if (isDashing)
            {
                Vector2 dash = new Vector2(movX * newSpeed, _rb.velocity.y);
                _rb.velocity = movement + dash;
            }
        } 
        else
        {
            _rb.velocity = Vector2.zero;
        }

       
    }
}
