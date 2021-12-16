using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public string goToPlace;
    public bool canExit;
    public GameObject text;
    private MeshRenderer myText;

    private void Start()
    {
        myText = GetComponent<MeshRenderer>();
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canExit = true;
           // Instantiate(text, transform.position, Quaternion.identity);
           myText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canExit = false;
            myText.enabled = false;
        }
    }

    private void Update()
   {
       var exit = Input.GetButtonDown("Fire3");
       if (canExit && exit)
       {
           SceneManager.LoadScene(goToPlace);
       }
   }
}