using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerB : MonoBehaviour
{
     public static GameManagerB instance;

     public CardB firstCard;
     public CardB secondCard;

     public AudioClip[] clips; // 0 : matching success, matching fail 
     AudioSource audioSource;

     private int lev = 2;
     private int cardCount = 0;

     bool isEnd = false;
     bool isClear = false;

     void Awake()
     {
          if (instance == null)
          {
               instance = this;
               DontDestroyOnLoad(gameObject);
          }
          else
          {
               Destroy(gameObject);
          }
     }

     // Start is called before the first frame update
     void Start()
     {
          audioSource = GetComponent<AudioSource>();
     }

     // Update is called once per frame
     void Update()
     {
          // time logic





          // stage clear
          // if lev == 1 || lev == 2
          // load next scene
          // else if lev == 3
          // load end scene

          // stage fail
          // load fail scene
     }

     public int GetLevel()
     {
          return lev;
     }

     public void SetLevel(int level)
     {
          lev = level;
     }

     public void SetCardCount(int count)
     {
          cardCount = count;
     }

     public bool GetIsEnd()
     {
          return isEnd;
     }     

     public void Matched()
     {
          if (firstCard.index == secondCard.index)
          {
               audioSource.clip = clips[0];
               audioSource.Play();

               firstCard.DestroyCard();
               secondCard.DestroyCard();
               cardCount -= 2;

               if (cardCount == 0)
               {
                    isClear = true;
                    EndStage();
               }
          }
          else
          {
               audioSource.clip = clips[1];
               audioSource.Play();

               firstCard.CloseCard();
               secondCard.CloseCard();
          }

          firstCard = null;
          secondCard = null;
     }

     void EndStage()
     {
          if (!isClear)
          {
               Debug.Log("stage fail");
               // load start scene or fail scene
               return;
          }

          if (lev == 3)
          {
               // load end scene
               Debug.Log("game clear");
               return;
          }

          lev++;
          Debug.Log("stage clear");
          Debug.Log($"next scene is Stage{lev} Scene");
          //SceneManager.LoadScene($"Stage{lev}Scene");
     }
}
