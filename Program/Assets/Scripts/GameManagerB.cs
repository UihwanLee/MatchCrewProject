using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerB : MonoBehaviour
{
     public static GameManagerB instance;

     public CardB firstCard;
     public CardB secondCard;

     public Text timeTxt;
     public Text endTxt;
     public GameObject endPannel;

     public AudioClip[] clips; // 0 : matching success, matching fail 
     AudioSource audioSource;

     int lev = 2;
     int cardCount = 0;

     float time;

     bool isRunning = true;
     bool isClear = false;

     void Awake()
     {
          if (instance == null)
          {
               instance = this;
          }
     }

     // Start is called before the first frame update
     void Start()
     {
          audioSource = GetComponent<AudioSource>();
          
          time = 15.0f;
          isRunning = true;
          isClear = false;
     }

     // Update is called once per frame
     void Update()
     {
          // time logic
          if (isRunning)
               time -= Time.deltaTime;

          if (time <= 0)
          {
               time = 0f;
               timeTxt.color = Color.red;
               isClear = false;
               isRunning = false;

               if (endPannel != null)
               {
                    endPannel.GetComponent<Text>().text = "Fail..";
                    endTxt.text = "Go Title";
                    endPannel.SetActive(true);
               }
          }

          if (timeTxt != null)
          { 
               timeTxt.text = time.ToString("N2"); 
          }
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

     public bool GetIsRunning()
     {
          return isRunning;
     }

     public bool GetIsClear()
     {
          return isClear;
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
                    isRunning = false;
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

          endPannel.GetComponent<Text>().text = "Clear!";
          endTxt.text = "Next Stage";
          endPannel.SetActive(true);
     }
}
