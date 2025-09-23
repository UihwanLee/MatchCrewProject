using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance;

    [Header("Loading UI")]
    public GameObject loadingScene;
    public Slider progressBar;
    public Text progressText;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        loadingScene.SetActive(false);
    }

    public void LoadScene(int sceneIndex)
    {
        if (loadingScene != null) loadingScene.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        StartCoroutine(LoadAsynchronously(operation));
    }

    public void LoadScene(string sceneName)
    {
        if (loadingScene != null) loadingScene.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        StartCoroutine(LoadAsynchronously(operation));
    }

    private IEnumerator LoadAsynchronously(AsyncOperation operation)
    {
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            float percentage = progress * 100f;

            if (progressBar != null)
                progressBar.value = progress;

            if (progressText != null)
                progressText.text = percentage.ToString("0") + "%";

            yield return null;
        }
    }

}
