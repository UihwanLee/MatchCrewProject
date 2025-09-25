using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCard : MonoBehaviour
{
    public void Card_Click()
    {
        gameObject.SetActive(false);    //카드 클릭시 사라짐
    }
    public void Card_Rendering(int num)
    {
        gameObject.GetComponent<Image>().sprite =Resources.Load<Sprite>($"Card{num}"); // 클릭시 클릭한 사진의 번호를 받아와
                                                                                       // 각번호에 해당하는카드를 보여줌
    }
}
