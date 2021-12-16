using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

public class Inventario : MonoBehaviour
{
    public List<GameObject> container = new List<GameObject>();
    public GameObject inv;
    public bool actInv;
    public GameObject selector;
    public int id;

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
        Navegar();
    }
}
