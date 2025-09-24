using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class Board : MonoBehaviour
{
    public GameObject card;
    void Start()
    {
        
        for (int i = 0; i < 4; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 2) * 3.5f;
            float y = (i / 2) * 3.5f;

            go.transform.position = new Vector2(x, y);
        }
    }
}
        



