using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening_1 : MonoBehaviour
{
    public GameObject Clickimage;

    void Start()
    {
        Clickimage.SetActive(false);          // 시작할 때 꺼두기
        Invoke("ShowObject", 3f);         // 3초 뒤 실행
    }

    void ShowObject()
    {
        Clickimage.SetActive(true);           // 오브젝트 켜짐
    }
}
