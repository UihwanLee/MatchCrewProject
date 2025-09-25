using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardB : MonoBehaviour
{
     public GameObject card;

     int lev;
     int[] arr;
     int[] arr1 = { 0, 0, 1, 1 };  // lev1
     int[] arr2 = { 2, 2, 3, 3, 4, 4 }; // lev2
     float distance;

     // Start is called before the first frame update
     void Start()
     {
          lev = GameManagerB.instance.GetLevel();

          if (lev < 0)
               return;

          if (lev > 4)
               return;

          switch (lev)
          {
               case 1:
                    arr = arr1;
                    break;
               case 2:
                    arr = arr2;
                    distance = 2f;
                    break;
               case 3:
                    int[] ints = { 5, 5 };
                    arr = arr1.Concat(arr2).Concat(ints).ToArray(); // lev3
                    break;
               default:
                    break;
          }

          arr = arr.OrderBy(x => Random.Range(0, arr.Length)).ToArray();
          Invoke($"CardSetting{lev}", 0f);
     }

     void CardSetting1()
     {
          //for (int i = 0; i < 4; i++)
          //{
          
          //     GameObject go = Instantiate(card, this.transform);

          //     float x = (i % 2) * distance - 1f;
          //     float y = (i % 2) * distance - 2.8f;

          //     go.transform.position = new Vector3(x, y, 0);
          //}

          //GameManagerB.instance.SetCardCount(arr.Length);
     }

     void CardSetting2()
     {
          for (int i = 0; i < 6; i++)
          {
               GameObject go = Instantiate(card, this.transform);

               float x = (i % 2) * distance - 1f;
               float y = (i % 3) * distance - 2.8f;

               go.transform.position = new Vector3(x, y, 0);
               go.GetComponent<CardB>().Setting(arr[i]);
          }

          GameManagerB.instance.SetCardCount(arr.Length);
     }

     void CardSetting3()
     {
          //for (int i = 0; i < 12; i++)
          //{
          
          //     GameObject go = Instantiate(card, this.transform);

          //     float x = (i % 3) * distance - 1f;
          //     float y = (i % 4) * distance - 2.8f;

          //     go.transform.position = new Vector3(x, y, 0);
          //}

          //GameManagerB.instance.SetCardCount(arr.Length);
     }
}
