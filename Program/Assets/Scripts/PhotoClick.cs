using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PhotoClick : MonoBehaviour
{
    public GameObject PhotoCard; // Ŭ���� ���;��ϴ� ī�� ������Ʈ
    public int photo_num;        // Ŭ���� ī���� ��ȣ
    public Animator animator;    

    float z;  

    private void Start()
    {
        animator = GetComponent<Animator>();         // ������Ʈ�� �ִϸ����͸� ������
        z = transform.rotation.eulerAngles.z;        // ���� z�� ������ z������ ���� 
                                                     // Quaternion -> Euler�� ������ (�������� ���� 1~2�� ������ �����ϱ�����)
    }

    private void Update()
    {
        float rotationFromAnim = animator.GetFloat("Rotation");             // �Ķ���Ͱ��� ������
        transform.rotation = Quaternion.Euler(0, 0, z + rotationFromAnim);  // �Ķ������ ���� ������ z���� ����
                                                                            //Euler�� �ٽú����Ͽ� ��������̼ǰ��� �־���
                                                                            //��, ������ �����̴� ��鸮�� �ִϸ��̼Ǳ���
    }

    public void click()     //Ŭ����
    {
        PhotoCard.SetActive(true);                                      //Ŭ���� ī�������Ʈ�� Ȱ��ȭ
        PhotoCard.GetComponent<PhotoCard>().Card_Rendering(photo_num);  //ī�������Ʈ���� �ش��ϴ� ī��� �����ϴ� �Լ�����
    }
}


