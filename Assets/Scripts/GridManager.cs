using System.Collections.Generic;
using Array2DEditor;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int SameColorCount;
    public List<Pin>clickablePins;
    public Array2DExampleEnum grid = new Array2DExampleEnum();
    public Pin pinPrefab;
    public float cellSize = 3.0f;
    public List<Pin> spawnedPins;
    
    private void Start()
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
                return new Color(148,0,211);
            case PinColorType.Yellow:
                return Color.yellow;
            case PinColorType.Green:
                return Color.green;
            case PinColorType.Pink:
                return Color.gray;
            default:
                break;
        }

        return Color.white;
    }

}