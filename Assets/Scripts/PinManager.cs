using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    public static PinManager instance;
    public List<GameObject> PinList;
    public Pin Pin;

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

    private void Start()
    {
       
    }
}
