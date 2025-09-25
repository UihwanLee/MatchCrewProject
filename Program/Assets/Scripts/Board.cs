
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;
    void Start()
    {
        int[] arr = { 0,1,2,3 }; //카드배열 리스트
        arr = arr.OrderBy(x => Random.Range(0f,3f)).ToArray();


        for (int i = 0; i < 4; i++)//카드배치
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 2) * 2.2f - 0.25f;
            float y = (i / 2) * 3.4f - 2.8f;

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(arr[i]);


            Debug.Log(arr[i]);
        }
        
    }

}
        



