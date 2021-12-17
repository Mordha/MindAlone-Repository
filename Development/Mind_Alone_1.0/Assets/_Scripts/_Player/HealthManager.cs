using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] public static int currentHealth;
    public Slider HealthBar;
    public int maxHealth;
    public bool flashActive;
    public float flashLenght;
    private float flashCounter;
    public int knockback;

    private SpriteRenderer _characterRenderer;
   
    // Start is called before the first frame update
    void Start()
    {
        _characterRenderer = GetComponent<SpriteRenderer>();
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = currentHealth;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (flashActive)
        {
            flashCounter -= Time.deltaTime;
            if (flashCounter > flashLenght * 0.66f)
            {
                ToogleColor(false);
            } else if (flashCounter > flashLenght * 0.33f)
            {
                ToogleColor(true);
            } else if (flashCounter > 0)
            {
                ToogleColor(false);
            }
            else
            {
                ToogleColor(true);
                flashActive = false;
                GetComponent<CapsuleCollider2D>().enabled = true;
                GetComponent<Rigidbody2D>().gravityScale = 1;
                GetComponent<PlayerMovement>().canMove = true;
            }
        }
        
    }

    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            HealthBar.value = 0;
        }

        if (flashLenght > 0)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<PlayerMovement>().canMove = false;
            flashActive = true;
            flashCounter = flashLenght;
            transform.Translate(Vector3.right * knockback * Time.deltaTime, Space.World);
        }
    }

    void ToogleColor(bool visible)
    {
        _characterRenderer.color = new Color(_characterRenderer.color.r, 
                                             _characterRenderer.color.g, 
                                             _characterRenderer.color.b,
                                             visible ? 1 : 0);
        
    }
}
