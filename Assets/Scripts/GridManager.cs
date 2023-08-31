using System.Collections.Generic;
using Array2DEditor;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Array2DExampleEnum grid = new Array2DExampleEnum();
    public Pin pinPrefab;
    public float cellSize = 3.0f;

    private void Start()
    {
        for (int i = 0; i < grid.GridSize.y; i++)
        {
            for (int j = 0; j < grid.GridSize.x; j++)
            {
                var cell = grid.GetCell(j, i);
                if (cell != PinColorType.empty)
                {
                    Vector3 pinPosition = new Vector3(j * cellSize, 0f, i * cellSize);
                    var newPin = Instantiate(pinPrefab, pinPosition, Quaternion.identity);
                    if (newPin.TryGetComponent(out Pin newPinRef))
                    {
                        newPinRef.SetColorMaterial(GetPinColor(i,j));
                    }
                }
            }
        }
    }

    private Color GetPinColor(int i, int j)
    {
        switch (grid.GetCell(j, i))
        {
            case PinColorType.empty:
            case PinColorType.blue:
                return Color.blue;
            case PinColorType.red:
                return Color.red;
            case PinColorType.purple:
                return new Color(148,0,211);
            case PinColorType.yellow:
                return Color.yellow;
            case PinColorType.green:
                return Color.green;
            case PinColorType.pink:
                return new Color(255,20,147);
            default:
                break;
        }

        return Color.white;
    }

}