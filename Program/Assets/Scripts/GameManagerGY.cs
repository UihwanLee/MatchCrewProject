
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public Card firstCard;
    public Card secondCard;
    
    
    public Text timeTxt;
    float time = 0.0f;

    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }

    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }

    public void Matched()
    {
        if (firstCard.num == secondCard.num)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }


}
