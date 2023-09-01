using System;
using System.Collections;
using System.Collections.Generic;
using Array2DEditor;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Pin : MonoBehaviour, IClickable
{
    public Dice Dice;
    public Vector2Int gridPosition;
    public bool isTurnedCorrect;
    public PinColorType pinColorType;
    
    [SerializeField] private MeshRenderer colorRenderer;
    private void Start()
    {
       HidePins();
    }

    private void HidePins()
    {
        transform.DORotate(new Vector3(180,0,0), 1f).SetDelay(3f).OnComplete(() =>
        {
            Dice.diceRollButton.transform.DOMove(new Vector3(164f, 60f, 0.3f), 2);
        });
    }
    
    public void OnTap()
    {
        GameManager.instance.InputManager.allowInput = false;
        transform.DORotate(new Vector3(0,0,0), 1f).OnComplete(() =>
        {
            CheckColor();
        });
        

    }

    public void OnRelease()
    {
        return;
    }

    private void CheckColor()
    {
        if (pinColorType == Dice.diceColorType)
        {
           
            isTurnedCorrect = true;
            GameManager.instance.ScoreTrackTrue();
            Dice.diceRollButton.transform.DOScale(Vector3.one, .3f).SetEase(Ease.Linear);
            if (GameManager.instance.GridManager.clickablePins.Count==1)
            {
                //finish method
                Debug.Log("finish");
            }
        }
        else
        {
            GameManager.instance.ScoreTrackFalse();
            
            transform.DORotate(new Vector3(180,0,0), 1f).SetDelay(0.5f);
            Dice.diceRollButton.transform.DOScale(Vector3.one, .3f).SetEase(Ease.Linear);
        }
        Debug.Log("p1: "+GameManager.instance.Player1Score);
        Debug.Log("p2: "+GameManager.instance.Player2Score);
    }

    
    private IEnumerator FalseColorMatch()
    {
        // Wait for 1.5 seconds
        yield return new WaitForSeconds(1.5f);

        // Perform the rotation here
        this.transform.DORotate(new Vector3(0f, 0, 0f), 1f);
    }
   
    public void SetColorMaterial(Color newColor)
    {
        if (colorRenderer != null)
        {
            colorRenderer.material.color = newColor;
        }
    }

   
}
