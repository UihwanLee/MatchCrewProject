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
    }
}
