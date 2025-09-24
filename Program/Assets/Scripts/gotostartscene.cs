using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotostartscene : MonoBehaviour
{
public void Gotostartscene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
