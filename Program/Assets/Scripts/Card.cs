using UnityEngine;

public class Card : MonoBehaviour
{

    public GameObject front;
    public GameObject back;
    public Animator anim;
    public SpriteRenderer frontImage;


    public int num;
    
    public void Setting(int number)
    {
        num = number % 2;
        frontImage.sprite = Resources.Load<Sprite>(num == 0 ? "Card2" : "Card3");
    }

    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

      //firstCard가 비었다면.
      if (GameManager.Instance.firstCard == null)
      {
          //firstCard에 내 정보를 넘겨준다.
          GameManager.Instance.firstCard = this;
      }


      //firstCard가 비어있지 않다면
      else
      {
          //secondCard에 내 정보를 넘겨준다.
          GameManager.Instance.secondCard = this;
          //Matched함수를 호출해준다.
          GameManager.Instance.Matched();
      }
    }
    
    //함수 위치를 어디에 넣을것인지!!확인해바
    public void DestroyCard()
    {
        Destroy(gameObject);
    }
        
    public void CloseCard() 
    { 
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
    
}
