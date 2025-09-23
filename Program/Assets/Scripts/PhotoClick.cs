using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class PhotoClick : MonoBehaviour
{

    public GameObject card;
    public int photo_num;


    public void click()
    {
        
         card.gameObject.SetActive(true);
         card.GetComponent<Card>().Card_Rendering(photo_num);
        
    }
}
    
