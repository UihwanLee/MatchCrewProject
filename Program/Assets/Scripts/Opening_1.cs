using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening_1 : MonoBehaviour
{
    public GameObject Clickimage;

    void Start()
    {
        Clickimage.SetActive(false);          // ������ �� ���α�
        Invoke("ShowObject", 3f);         // 3�� �� ����
    }

    void ShowObject()
    {
        Clickimage.SetActive(true);           // ������Ʈ ����
    }
}
