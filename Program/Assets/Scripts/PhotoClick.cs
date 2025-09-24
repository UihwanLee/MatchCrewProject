using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class PhotoClick : MonoBehaviour
{

    public GameObject PhotoCard;
    public int photo_num;


    public void click()
    {
        
         PhotoCard.gameObject.SetActive(true);
        PhotoCard.GetComponent<PhotoCard>().Card_Rendering(photo_num);
        
    }
}
    
