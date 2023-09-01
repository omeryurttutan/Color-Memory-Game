using System;
using System.Collections;
using System.Collections.Generic;
using Array2DEditor;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    
    public GameObject sides;
    private Image _image;
    public Button diceRollButton;
    public int diceRandomCount;
    public PinColorType diceColorType;

    private void Start()
    {
        _image = GetComponent<Image>();
        diceRollButton.onClick.AddListener(()=>StartCoroutine(RepeatRandomColor()));
        

    }

    private void SetColorToImage(Color newColor)
    {
        _image.color = newColor;
    }
    
    private IEnumerator RepeatRandomColor()
    {
        
        _image.transform.DOMove(new Vector3(164f, 120f, 0.3f), 2);
      
        var gridManagerRef = GameManager.instance.GridManager;
        var oldPinType = PinColorType.Empty;
        
        diceRollButton.transform.DOScale(Vector3.zero, .3f).SetEase(Ease.Linear);
        for (int i = 0; i < diceRandomCount; i++)
        {
            do
            {
                diceColorType = gridManagerRef.GetRandomClickablePinColorType();
                yield return null;
            } while (diceColorType == oldPinType);
            oldPinType = diceColorType;
            
            var rndColor = gridManagerRef.GetPinColor(diceColorType); 
            SetColorToImage(rndColor);
            yield return new WaitForSeconds(0.2f);
        }
        sides.SetActive(true);
        GameManager.instance.InputManager.allowInput = true;
    }
}
