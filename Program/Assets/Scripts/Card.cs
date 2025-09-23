using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public SpriteRenderer Cardimg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Card_Click()
    {
        gameObject.SetActive(false);
    }
    public void Card_Rendering(int num)
    {
        Cardimg.sprite = Resources.Load<Sprite>($"Card{num}");
    }
}
