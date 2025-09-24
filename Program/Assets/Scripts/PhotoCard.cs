using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCard : MonoBehaviour
{
    public Animator animator;
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
        gameObject.GetComponent<Image>().sprite =Resources.Load<Sprite>($"Card{num}");
        animator.Play("Photo_Card");
        
    }
    
}
