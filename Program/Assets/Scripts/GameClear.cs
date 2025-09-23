using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    public Canvas Canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Game_Clear()
    {
        Canvas.gameObject.SetActive(true);
    }
    public void TTS()
    {
        SceneManager.LoadScene("StartScene");
    }
}
