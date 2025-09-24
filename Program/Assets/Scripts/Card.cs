using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public SpriteRenderer front;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setting(int number)
    {
        front.sprite = Resources.Load<Sprite>($"Card_Gayeong");

    }
}
