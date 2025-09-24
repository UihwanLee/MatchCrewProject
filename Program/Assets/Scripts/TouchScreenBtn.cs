using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouochScreenBtn : MonoBehaviour
{
    public void TouchScreen()
    {
        SceneManager.LoadScene("StartScene");
    }
}