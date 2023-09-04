using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public Pin Pin;
    public void OnClickPlay()
    {
        foreach (var spawnedPin in GameManager.instance.GridManager.spawnedPins)
        {
            spawnedPin.HidePin();
            GameManager.instance.StartTimer = true;
            GameManager.instance.currentTime = GameManager.instance.countdownTime;
        }
        
        gameObject.SetActive(false);
    }
    
}
