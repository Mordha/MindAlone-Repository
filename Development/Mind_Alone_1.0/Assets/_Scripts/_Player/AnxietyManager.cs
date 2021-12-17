using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class AnxietyManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider anxietyBar;
    public float minAnx;
    public float currentAnx;
    public bool canAnxGrow;
    public float anxPerSec;
    public int activeScene;
    
    void Start()
    {
        currentAnx = minAnx;
    }

    // Update is called once per frame
    void Update()
    {
        anxietyBar.value = currentAnx;
        if (currentAnx < minAnx)
        {
            currentAnx = 0;
        }

        if (currentAnx >= 100)
        {
            anxPerSec = 0f;
        }

        if (canAnxGrow)
        {
            currentAnx += anxPerSec * Time.deltaTime;
        } 
    }
}
