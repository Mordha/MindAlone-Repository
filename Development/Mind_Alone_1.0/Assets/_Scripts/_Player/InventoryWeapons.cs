using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWeapons : MonoBehaviour
{
    public List<GameObject> bag = new List<GameObject>();
    public GameObject inv;
    public bool actInv;
    public GameObject selectorWeapon;
    public int id;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapons"))
        {
            for (int i = 0; i < bag.Count; i++)
            {
                if (bag[i].GetComponent<Image>().enabled == false)
                {
                    bag[i].GetComponent<Image>().enabled = true;
                    bag[i].GetComponent<Image>().sprite = other.GetComponent<SpriteRenderer>().sprite;
                    break;
                }
            }
            Destroy(other.gameObject);
        } 
    }

    public void Navegar()
    {
        if (Input.GetKeyDown(KeyCode.P) && id < bag.Count - 1)
        {
            id++;
        }

        if (Input.GetKeyDown(KeyCode.O) && id > 0)
        {
            id--;
        }

        selectorWeapon.transform.position = bag[id].transform.position;
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
