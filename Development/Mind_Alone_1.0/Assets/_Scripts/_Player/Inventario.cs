using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class Inventario : MonoBehaviour
{
    public List<GameObject> container = new List<GameObject>();
    public GameObject inv;
    public bool actInv;
    public GameObject selector;
    public int id;
    public string itemName;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Objects"))
        {
            for (int i = 0; i < container.Count; i++)
            {
                if (container[i].GetComponent<Image>().enabled == false)
                {
                    container[i].GetComponent<Image>().enabled = true;
                    container[i].GetComponent<Image>().sprite = other.GetComponent<SpriteRenderer>().sprite;
                    break;
                }
            }
            
            Destroy(other.gameObject);
        }
    }

    public void Navegar()
    {
        if (Input.GetKeyDown(KeyCode.P) && id < container.Count - 1)
        {
            id++;
        }

        if (Input.GetKeyDown(KeyCode.O) && id > 0)
        {
            id--;
        }

        selector.transform.position = container[id].transform.position;
    }

    public void UseItem()
    {
        if (itemName == "potion1" && Input.GetKeyDown(KeyCode.I) && HealthManager.currentHealth < 100)
        {
            HealthManager.currentHealth += 10;
            container[id].GetComponent<Image>().enabled = false;
        }
    }

    public void ItemName()
    {
        if (container[id].GetComponent<Image>().enabled == false)
        {
            itemName = "null";
        }
        else
        {
            itemName = container[id].GetComponent<Image>().sprite.name;
        }
        
    }
   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (actInv)
        {
            inv.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            inv.SetActive(false);
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            actInv = !actInv;
        }*/
        ItemName();
        Navegar();
        UseItem();
        
    }
}
