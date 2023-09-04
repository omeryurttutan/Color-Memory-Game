using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("-- Gameplay Values --")] 
    public Pin pin;
    public WınnerUI wınnerUI;
    public TextMeshProUGUI textMeshProUGUIPlayerTurn;
    public TextMeshProUGUI textMeshProP1Score;
    public TextMeshProUGUI textMeshProP2Score;
    public int Player1Score;
    public int Player2Score;
    public TextMeshProUGUI wınner;
    public bool isPlayer1Turn = true;
    public TextMeshProUGUI timerText;
    public float countdownTime = 4.0f;
    public float currentTime = 0.0f;
    public bool StartTimer;
    
    
    [Space(3.5f)][Header("-- Manager References --")] 
    [SerializeField] private GridManager gridManager;
    [SerializeField] private InputManager inputManager;

   

    public GridManager GridManager => gridManager;
    public InputManager InputManager => inputManager;


    private void Update()
    {
        if (StartTimer)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0.0f)
            {
                currentTime = 0.0f;
                StartTimer = false;
            }

            
        }
        UpdateTimerText();
    }

    private void Start()
    {
        textMeshProP1Score.text = "Score: 0";
        textMeshProP2Score.text = "Score: 0";
    }

    public void ScoreTrackTrue()
    {
        if (instance.isPlayer1Turn)
        {
            instance.isPlayer1Turn = true;
            instance.Player1Score++;
            textMeshProP1Score.text = "Score: "+ Player1Score;
            
        }
        else
        {
            instance.isPlayer1Turn = false;
            instance.Player2Score++;
            textMeshProP2Score.text = "Score: "+ Player2Score;
            
        }
    }

    private void UpdateTimerText()
    {
        int seconds = Mathf.FloorToInt(currentTime);
        timerText.text =  seconds.ToString();
    }
    public void ScoreTrackFalse()
    {
        if (isPlayer1Turn)
        {
            textMeshProUGUIPlayerTurn.text = "PLAYER 2 TURN";
            isPlayer1Turn = false;
        }
        else
        {
            textMeshProUGUIPlayerTurn.text = "PLAYER 1 TURN";
            isPlayer1Turn = true;
        }
        
    }
    
    public void OnWin()
    {
        if (Player1Score>Player2Score)
        {
           
            //display winner : player 1 
            wınner.text = "WINNER: PLAYER 1";
            wınnerUI.gameObject.SetActive(true);
            wınnerUI.WinPanel();
            
           
        }

        else if (Player2Score>Player1Score)
        {
           
            //display winner : player 2 
            wınner.text = "WINNER: PLAYER 2";
            wınnerUI.gameObject.SetActive(true);
            wınnerUI.WinPanel();

        }
        else
        {
            
            wınner.text = "DRAW";
            wınnerUI.gameObject.SetActive(true);
            wınnerUI.WinPanel();
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
    
