using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool allowInput = false;
    public Camera cam; 
    public LayerMask PinLayer;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && allowInput)
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