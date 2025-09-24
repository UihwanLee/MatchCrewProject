using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushBtn : MonoBehaviour
{
    public void StartGame()
    {
        LoadingManager.Instance.LoadScene("MainScene");
    }
    public void Gallery()
    {
        LoadingManager.Instance.LoadScene("GalleryScene");
    }
    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
