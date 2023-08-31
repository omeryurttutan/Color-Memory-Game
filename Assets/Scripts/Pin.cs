using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Pin : MonoBehaviour, IClickable
{
    public bool PinsHided;
    [SerializeField] private MeshRenderer colorRenderer;
    private void Start()
    {
       HidePins();
    }

    private void Update()
    {
        CheckPins();
    }

    private void HidePins()
    {
        InputManager.instance.allowInput = false;
        transform.DORotate(new Vector3(180,0,0), 1f).SetDelay(4f);
    }
    
    public void OnTap()
    {
        if (InputManager.instance.allowInput)
        {
            transform.DORotate(new Vector3(0,0,0), 1f);
            CheckColor();
        }
        
           
        
           
        

        // if (//doğru renkmi)
        // {
        //     //oyuncuya +1 puan
        // }
        // else()
        // {
        //     //ters dön
        //     //oyuncu sırası değiştir
        // }

    }

    public void OnRelease()
    {
        return;
    }

    private void CheckColor()
    {
       
    }
    
    private IEnumerator FalseColorMatch()
    {
        // Wait for 1.5 seconds
        yield return new WaitForSeconds(1.5f);

        // Perform the rotation here
        this.transform.DORotate(new Vector3(0f, 0, 0f), 1f);
    }
    public IEnumerator Wait(float seconds)
    {
       
        yield return new WaitForSeconds(seconds);

       
    }
    public void SetColorMaterial(Color newColor)
    {
        if (colorRenderer != null)
        {
            colorRenderer.material.color = newColor;
        }
    }

    private void CheckPins()
    {
        if (gameObject.transform.rotation == Quaternion.Euler(180,0,0))
        {
            InputManager.instance.allowInput = true;
        }
    }
}
