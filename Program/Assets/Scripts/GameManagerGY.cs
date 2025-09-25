using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public Text timeTxt;
    float time = 0.0f;

    public Card firstCard;
    public Card secondCard;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }

    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }

    public void Matched()
    {
        if (firstCard == secondCard)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
    }
    
   
}
