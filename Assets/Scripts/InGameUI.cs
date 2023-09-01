using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public TextMeshProUGUI textMeshProWınnerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnWin()
    {
        textMeshProWınnerText.text = "WINNER: " + GameManager.instance.wınner;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
