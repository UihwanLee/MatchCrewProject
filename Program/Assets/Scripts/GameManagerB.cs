using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerB : MonoBehaviour
{
     public static GameManagerB instance;

     private int lev = 1;
     private int cardCount = 0;

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
}
