using System;
using System.Collections;
using System.Collections.Generic;
using Array2DEditor;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Array2DBool grid = new Array2DBool();
    public Pin pin;
    public float cellSize = 3.0f; // Adjust this to match your grid cell size

    private void Start()
    {
        for (int i = 0; i < grid.GridSize.y; i++)
        {
            for (int j = 0; j < grid.GridSize.x; j++)
            {
                var cell = grid.GetCell(j, i);
                if (cell == true)
                {
                     Vector3 pinPosition = new Vector3(j * cellSize, 0f, i * cellSize);
                     Instantiate(pin.gameObject, pinPosition, Quaternion.identity);
                     PinManager.instance.PinList.Add(pin.gameObject);
                }
            }
        }
    }
}