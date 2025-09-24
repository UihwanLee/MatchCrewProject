using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance;

    [Header("Loading UI")]
    public GameObject loadingScene;                 // �ε� ȭ��
    public Slider progressBar;                      // �ε� ���� ��
    public Text progressText;                       // �ε� �ۼ�Ʈ
    public Text noticeLoadingText;                  // �ε��� �ؽ�Ʈ
    public Image polaroidImage;                     // ������̵� �̹���

    [Header("Team List")]
    public Sprite[] polaroidSprites;                // ������̵� ���� ����Ʈ

    private bool isLoading;                         // �ε� Ȯ�� ����
    private int spriteIndex;                        // ����Ʈ �ε���


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
        // ���� �ʱ�ȭ
        isLoading = false;
        loadingScene.SetActive(false);

        // ������̵� ���� �Լ� Invoke
        spriteIndex = 0;
        InvokeRepeating("LoadingAnim", 0f, 1f);
    }

    // ������̵� ���� �����̵� �ִϸ��̼� �÷���
    public void LoadingAnim()
    {
        // ����Ʈ ����ó��
        if (polaroidSprites == null) return;

        // �ε��� ���߱�
        spriteIndex = spriteIndex % polaroidSprites.Length;

        // ������̵� ���� ����
        polaroidImage.sprite = polaroidSprites[spriteIndex];

        // �ε� �ؽ�Ʈ ����
        noticeLoadingText.text = (spriteIndex % 2 == 0) ? "�ε���.." : "�ε���...";

        // �ε��� ����
        spriteIndex++;
    }

    // Scene �ε����� �ε�
    public void LoadScene(int sceneIndex)
    {
        // �̹� �ε� ���� �� ����ó��
        if(isLoading) return;

        // �ε�ȭ�� Ȱ��ȭ
        if (loadingScene != null) loadingScene.SetActive(true);

        // �ε� ����
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        StartCoroutine(LoadAsynchronously(operation));
    }

    // Scene �̸����� �ε�
    public void LoadScene(string sceneName)
    {
        // �̹� �ε� ���� �� ����ó��
        if (isLoading) return;

        // �ε�ȭ�� Ȱ��ȭ
        if (loadingScene != null) loadingScene.SetActive(true);

        // �ε� ���� ����
        polaroidSprites = polaroidSprites.OrderBy(x=>Random.Range(0, 3)).ToArray();

        // �ε� ����
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        StartCoroutine(LoadAsynchronously(operation));
    }

    // �ε� ���μ���
    private IEnumerator LoadAsynchronously(AsyncOperation operation)
    {
        while (!operation.isDone)
        {
            // �ε� ���� �� (0~1) ������ ��ȯ
            float progress = Mathf.Clamp01(operation.progress / .9f);

            // 100�� ���ؼ� �ۼ�Ʈ ���ϱ�
            float percentage = progress * 100f;

            // ���� �� ������Ʈ
            if (progressBar != null)
                progressBar.value = progress;

            // �ۼ�Ʈ �ؽ�Ʈ ������Ʈ
            if (progressText != null)
                progressText.text = percentage.ToString("0") + "%";

            yield return null;
        }

        // �ε� �� ������ �ε� ȭ�� ��Ȱ��ȭ
        if(loadingScene != null) loadingScene.SetActive(false);
    }

}
