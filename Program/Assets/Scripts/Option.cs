using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
     public GameObject option;

     AudioSource audioSource;

     public void OpenOption()
     {
          // if open option window, stop game
          Time.timeScale = 0.0f;
          option.SetActive(true);

          // test
          audioSource = GetComponent<AudioSource>();
          // Set AudioClip Parameter in AudioSource Component
          audioSource.PlayOneShot(audioSource.clip);
     }

     public void CloseOption()
     {
          // if close option window, restart game
          Time.timeScale = 1.0f;
          option.SetActive(false);
     }
}
