using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("-- Gameplay Values --")]
    
    
    [Space(3.5f)][Header("-- Manager References --")] 
    [SerializeField] private GridManager gridManager;
    [SerializeField] private InputManager inputManager;

    public GridManager GridManager => gridManager;
    public InputManager InputManager => inputManager;
    
    #region Singleton

    public static GameManager instance;

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

    #endregion
    
    
    
    

}
    
