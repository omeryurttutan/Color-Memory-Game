using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Pin : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        transform.DORotate(new Vector3(180,0,0), 1f).SetDelay(4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
