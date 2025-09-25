using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotostartscene : MonoBehaviour
{
    public string StartScene;
    public void LoadScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
