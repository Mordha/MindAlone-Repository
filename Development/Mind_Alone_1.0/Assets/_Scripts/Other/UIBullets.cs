using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBullets : MonoBehaviour
{
    private Text _text;
    public InventoryWeapons targetShooting;
    public int id;
    
    // Start is called before the first frame update
    void Awake()
    {
        _text = GetComponent<Text>();
    }

   

    // Update is called once per frame
    void Update()
    {
        if (id == 1 && InventoryWeapons.weaponName == "gun1")
        {
            _text.enabled = true;
            _text.text = targetShooting.bulletsCant.ToString();
            

        } else if (id == 2 && InventoryWeapons.weaponName ==  "gun2")
        {
            _text.enabled = true;
            _text.text = targetShooting.bulletsCant2.ToString();
        } else if (id == 3 && InventoryWeapons.weaponName == "gun3")
        {
            _text.enabled = true;
            _text.text = targetShooting.bulletsCant3.ToString();
        }
        else
        {
            _text.enabled = false;
        }
    }
}
