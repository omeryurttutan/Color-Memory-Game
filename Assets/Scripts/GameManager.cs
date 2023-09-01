using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("-- Gameplay Values --")]
    
    
    [Space(3.5f)][Header("-- Manager References --")] 
    [SerializeField] private GridManager gridManager;
    [SerializeField] private InputManager inputManager;

    public String wınner;
    public Pin pin;
    public TextMeshProUGUI textMeshProP1Score;
    public TextMeshProUGUI textMeshProP2Score;
    public int Player1Score;
    public int Player2Score;
    public bool isPlayer1Turn = true;
    public GridManager GridManager => gridManager;
    public InputManager InputManager => inputManager;

    private void Start()
    {
        textMeshProP1Score.text = "P1:";
        textMeshProP2Score.text = "P2:";
    }

    public void ScoreTrackTrue()
    {
        if (GameManager.instance.isPlayer1Turn)
        {
            instance.isPlayer1Turn = false;
            instance.Player1Score++;
            textMeshProP1Score.text = "P1: "+ Player1Score;
            
        }
        else
        {
            instance.isPlayer1Turn = true;
            instance.Player2Score++;
            textMeshProP2Score.text = "P2: "+ Player2Score;
            
        }

       
    }

    public void ScoreTrackFalse()
    {
        if (isPlayer1Turn)
        {
            isPlayer1Turn = false;
        }
        else
        {
            isPlayer1Turn = true;
        }
        
    }

    public void Finish()
    {
        if (Player1Score>Player2Score)
        {
            //display winner : player 1 
            wınner = "PLAYER 1";
        }
        else
        {
            //display winner : player 2 
            wınner = "PLAYER 2";
        }
    }
    
   
    
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
    
