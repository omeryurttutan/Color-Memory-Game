using System;
using System.Collections;
using System.Collections.Generic;
using Array2DEditor;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public Pin Pin;
    
    public GameObject sides;
    public Image _image;
    public Button diceRollButton;
    public int diceRandomCount;
    public PinColorType diceColorType;

    private void Start()
    {
        _image = GetComponent<Image>();
        _image.transform.localScale = Vector3.zero;
        diceRollButton.onClick.AddListener(()=>StartCoroutine(RepeatRandomColor()));
        

    }

    private void SetColorToImage(Color newColor)
    {
        _image.color = newColor;
    }
    
    private IEnumerator RepeatRandomColor()
    {
        GameManager.instance.GridManager.restartButton.gameObject.SetActive(false);
        _image.gameObject.SetActive(true);
        _image.gameObject.transform.DOScale(Vector3.one, 3f).SetEase(Ease.OutBack).From(0);
        
      
        var gridManagerRef = GameManager.instance.GridManager;
        var oldPinType = PinColorType.Empty;
        
        diceRollButton.transform.DOScale(Vector3.zero, .15f).SetEase(Ease.OutBack);
        for (int i = 0; i < diceRandomCount; i++)
        {
            if (GameManager.instance.GridManager.IsColorCountMoreThanOne())
            {
                do
                {
                    diceColorType = gridManagerRef.GetRandomClickablePinColorType();
                    yield return null;
                } while (diceColorType == oldPinType);
                oldPinType = diceColorType;
            }
            else
                diceColorType = gridManagerRef.GetRandomClickablePinColorType();
               
            var rndColor = gridManagerRef.GetPinColor(diceColorType); 
            SetColorToImage(rndColor);
            yield return new WaitForSeconds(0.2f);
        }


        sides.SetActive(true);
        GameManager.instance.InputManager.allowInput = true;
    }
}
