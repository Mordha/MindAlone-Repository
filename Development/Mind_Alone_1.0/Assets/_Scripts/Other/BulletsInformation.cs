using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class BulletsInformation : MonoBehaviour
{
    public int ammoID;

    public int ammoCant;

    public InventoryWeapons target;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ammoID == 1)
            {
                target.bulletsCant += ammoCant;
                Destroy(gameObject);
            }
            else if (ammoID == 2)
            {
                target.bulletsCant2 += ammoCant;
                Destroy(gameObject);
            }
            else if (ammoID == 3)
            {
                target.bulletsCant3 += ammoCant;
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
