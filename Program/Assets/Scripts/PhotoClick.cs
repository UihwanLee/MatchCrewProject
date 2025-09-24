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
    public GameObject PhotoCard;
    public int photo_num;
    public Animator animator;

    float z;

    private void Start()
    {
        animator = GetComponent<Animator>();
        z = transform.rotation.eulerAngles.z; // Quaternion -> Euler·Î º¯°æ
    }

    private void Update()
    {
        float rotationFromAnim = animator.GetFloat("Rotation");
        transform.rotation = Quaternion.Euler(0, 0, z + rotationFromAnim);
    }

    public void click()
    {
        PhotoCard.SetActive(true);
        PhotoCard.GetComponent<PhotoCard>().Card_Rendering(photo_num);
    }
}


