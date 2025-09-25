using UnityEngine;

public class Card : MonoBehaviour
{

    public GameObject front;
    public GameObject back;

    public Animator anim;

    public SpriteRenderer frontImage;


    public void Setting(int number)
    {
        frontImage.sprite = Resources.Load<Sprite>(number % 2 == 0 ? "Card_Gayeong" : "Card_LeeHwan");
    }

    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }

        else
        {
            GameManager.Instance.secondCard = this;
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
