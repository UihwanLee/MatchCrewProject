using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageEndButton : MonoBehaviour
{
    public Canvas ClearCanvas;
     public void LoadNextScene()
     {
          if (!GameManagerB.instance.GetIsClear())
          {
               GameManagerB.instance.SetLevel(1);
               SceneManager.LoadScene("StartScene");
               //LoadingManager.Instance.LoadScene("StartScene");
               return;
          }

          int lev = GameManagerB.instance.GetLevel();

          if (lev == 3)
          {
               // load ending scene
               Debug.Log("game clear");
            GameManagerB.instance.SetLevel(1);
            ClearCanvas.gameObject.SetActive(true);
           
                              

          }
          else
          {
               // load next stage scene
               lev++;
               GameManagerB.instance.SetLevel(lev);
               SceneManager.LoadScene($"Stage{lev}Scene");
               //LoadingManager.Instance.LoadScene($"Stage{lev}Scene");
          }
     }
}
