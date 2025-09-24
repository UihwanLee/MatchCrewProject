using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageEndButton : MonoBehaviour
{
     public void LoadNextScene()
     {
          if (!GameManagerB.instance.GetIsClear())
          {
               LoadingManager.Instance.LoadScene("StartScene");
               return;
          }

          int lev = GameManagerB.instance.GetLevel();

          if (lev == 3)
          {
               // load ending scene
               Debug.Log("game clear");
          }
          else
          {
               // load next stage scene
               //lev++;
               LoadingManager.Instance.LoadScene($"Stage{lev}Scene");
          }
     }
}
