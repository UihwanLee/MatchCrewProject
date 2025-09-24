using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushBtn : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameStart");
    }
    public void Gallery()
    {
        SceneManager.LoadScene("GalleryScene");
    }
    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
