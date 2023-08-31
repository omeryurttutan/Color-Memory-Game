using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorGenerater : MonoBehaviour
{
    public Pin Pin;
    public GameObject[] SetactiveColor;
    public GameObject Blue;
    public GameObject Red;
    public GameObject Yellow;
    public GameObject Green;
    public GameObject Pink;
    public GameObject Purple;
    
    public float Time = 5;
    // Start is called before the first frame update
    void Start()
    {
        SetactiveColor[0] = (Blue);
        SetactiveColor[0] = (Red);
        SetactiveColor[0] = (Yellow);
        SetactiveColor[0] = (Green);
        SetactiveColor[0] = (Pink);
        SetactiveColor[0] = (Purple);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DisplayRandomColor()
    {
        
        int random = Random.Range(0, 5);
        SetactiveColor[random].SetActive(true);
        Pin.Wait(0.5f);
        SetactiveColor[random].SetActive(false);
        
    }
}
