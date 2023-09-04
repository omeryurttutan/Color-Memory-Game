using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WınnerUI : MonoBehaviour
{
    public Dice Dice;
    public void WinPanel()
    {
        GameManager.instance.GridManager.restartButton.gameObject.transform.DOMove(new Vector3(395f,17f,0f),0.0001f);
        Dice.gameObject.transform.DOMove(new Vector3(395f,17f,0f),0.0001f);
        GameManager.instance.GridManager.playerTurn.SetActive(false);
        GameManager.instance.GridManager.p1.gameObject.SetActive(false);
        GameManager.instance.GridManager.p2.gameObject.SetActive(false);
        
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
