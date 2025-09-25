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
    public GameObject PhotoCard; // 클릭시 나와야하는 카드 오브젝트
    public int photo_num;        // 클릭한 카드의 번호
    public Animator animator;    

    float z;  

    private void Start()
    {
        animator = GetComponent<Animator>();         // 오브젝트의 애니메이터를 가져옴
        z = transform.rotation.eulerAngles.z;        // 변수 z에 현재의 z각도를 저장 
                                                     // Quaternion -> Euler로 변경함 (움직임을 각도 1~2도 단위로 수행하기위함)
    }

    private void Update()
    {
        float rotationFromAnim = animator.GetFloat("Rotation");             // 파라미터값을 가져옴
        transform.rotation = Quaternion.Euler(0, 0, z + rotationFromAnim);  // 파라미터의 값과 원래의 z값을 더해
                                                                            //Euler로 다시변경하여 현재로테이션값에 넣어줌
                                                                            //즉, 사진이 움직이는 흔들리는 애니메이션구현
    }

    public void click()     //클릭시
    {
        PhotoCard.SetActive(true);                                      //클릭시 카드오브젝트가 활성화
        PhotoCard.GetComponent<PhotoCard>().Card_Rendering(photo_num);  //카드오브젝트내의 해당하는 카드로 변경하는 함수실행
    }
}


