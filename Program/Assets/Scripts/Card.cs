using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    int idx = 0;

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
        idx = number;
        Resources.Load<Sprite>($"Card{idx}");
    }
}
