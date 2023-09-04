using System;
using System.Collections.Generic;
using Array2DEditor;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{
    public GameObject playerTurn;
    public GameObject timeText;
    public GameObject restartButton;
    public GameObject p1;
    public GameObject p2;
    public int SameColorCount;
    public List<Pin>clickablePins;
    public Array2DExampleEnum grid = new Array2DExampleEnum();
    public Pin pinPrefab;
    public float cellSize = 3.0f;
    public List<Pin> spawnedPins;

   

    private void Start()
    {
       DisplayGrid();
    }
    
    
    public void DisplayGrid()
    {
        spawnedPins = new List<Pin>();
        for (int i = 0; i < grid.GridSize.y; i++)
        {
            for (int j = 0; j < grid.GridSize.x; j++)
            {
                var cell = grid.GetCell(j, grid.GridSize.y - i -1);
                if (cell != PinColorType.Empty)
                {
                    Vector3 pinPosition = new Vector3(j * cellSize, 0f, i * cellSize);
                    var newPin = Instantiate(pinPrefab, pinPosition, Quaternion.identity);
                    if (newPin.TryGetComponent(out Pin newPinRef))
                    {
                        newPinRef.gridPosition = new Vector2Int(j, i);
                        newPinRef.pinColorType = cell;
                        newPinRef.SetColorMaterial(GetPinColor(newPinRef.pinColorType));
                        spawnedPins.Add(newPinRef);
                        

                    }
                }
            }
        }
    }

    public void DisplayUI()
    {
        p1.gameObject.SetActive(true);
        p2.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        p1.gameObject.transform.DOScale(Vector3.one, 3f).SetEase(Ease.OutBack).From(0);
        p2.gameObject.transform.DOScale(Vector3.one, 3f).SetEase(Ease.OutBack).From(0);
        restartButton.gameObject.transform.DOScale(Vector3.one, 2f).SetEase(Ease.OutBack).SetLoops(-1,LoopType.Yoyo).From(1.3f);
        timeText.gameObject.SetActive(false);
        playerTurn.gameObject.SetActive(true);
    }
    
    

    public PinColorType GetRandomClickablePinColorType()
    {
        clickablePins.Clear();
        foreach (var spawnedPin in spawnedPins)
        {
            if (!spawnedPin.isTurnedCorrect)
                clickablePins.Add(spawnedPin);
        }
        var rndPin = clickablePins[Random.Range(0,clickablePins.Count)];
        return rndPin.pinColorType;
        
    }

    public bool IsColorCountMoreThanOne()
    {
        for (int i = 1; i < clickablePins.Count; i++)
        {
            if (clickablePins[0].pinColorType == clickablePins[i].pinColorType)
            {
                SameColorCount++;
            }
        }

        return clickablePins.Count == SameColorCount - 1;
    }
    
    

    public Color GetPinColor(PinColorType pinColorType)
    {
        switch (pinColorType)
        {
            case PinColorType.Empty:
                return Color.white;
            case PinColorType.Blue:
                return Color.blue;
            case PinColorType.Red:
                return Color.red;
            case PinColorType.Purple:
                return new Color(0.54f,0.4f,0.84f);
            case PinColorType.Yellow:
                return Color.yellow;
            case PinColorType.Green:
                return Color.green;
            case PinColorType.Pink:
                return Color.magenta;
            default:
                break;
        }

        return Color.white;
    }

}