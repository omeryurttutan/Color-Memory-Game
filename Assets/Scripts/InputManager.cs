using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool allowInput = true;
    public static InputManager instance;
    public Camera cam; 
    public LayerMask PinLayer;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        CheckHitsPin();
    }
    
    private void CheckHitsPin()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        
        if (Physics.Raycast(ray,out hit,100,PinLayer))
        {
            if (hit.collider.TryGetComponent(out IClickable clickable))
                clickable.OnTap();
        }
        
    }
    
  
   
}