using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCard : MonoBehaviour
{
    public void Card_Click()
    {
        gameObject.SetActive(false);    //ī�� Ŭ���� �����
    }
    public void Card_Rendering(int num)
    {
        gameObject.GetComponent<Image>().sprite =Resources.Load<Sprite>($"Card{num}"); // Ŭ���� Ŭ���� ������ ��ȣ�� �޾ƿ�
                                                                                       // ����ȣ�� �ش��ϴ�ī�带 ������
    }
}
