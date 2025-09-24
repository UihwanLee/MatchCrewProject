using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardB : MonoBehaviour
{

     public GameObject front;
     public GameObject back;

     public SpriteRenderer frontImage;

     Animator anim;
     AudioSource audioSource;

     public int index = 0;

     // Start is called before the first frame update
     void Start()
     {
          anim = GetComponent<Animator>();
          audioSource = GetComponent<AudioSource>();
     }

     // Update is called once per frame
     void Update()
     {

     }

     public void Setting(int number)
     {
          index = number;
          frontImage.sprite = Resources.Load<Sprite>($"Images\\front{index}");
     }

     public void OpenCard()
     {
          if (GameManagerB.instance.secondCard != null)
               return;

          if (GameManagerB.instance.GetIsEnd())
               return;

          audioSource.Play();
          anim.SetBool("isOpen", true);
          front.SetActive(true);
          back.SetActive(false);

          if (GameManagerB.instance.firstCard == null)
          {
               GameManagerB.instance.firstCard = this;
          }
          else
          {
               GameManagerB.instance.secondCard = this;
               GameManagerB.instance.Matched();
          }
     }

     public void DestroyCard()
     {
          Invoke("DestroyCardInvoke", 0.5f);
     }

     public void DestroyCardInvoke()
     {
          Destroy(gameObject);
     }

     public void CloseCard()
     {
          Invoke("CloseCardInvoke", 0.5f);
     }

     public void CloseCardInvoke()
     {
          anim.SetBool("isOpen", false);
          front.SetActive(false);
          back.SetActive(true);
     }
}
