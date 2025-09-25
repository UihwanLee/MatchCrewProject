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

    [Header("Polaroid List")]
    public Sprite[] polaroidSprites;                // ������̵� ���� ����Ʈ
    public Image[] polaroidCanvasList;              // ������̵� ĵ���� ����Ʈ

    private bool isLoading;                         // �ε� Ȯ�� ����

    public float slideSpeed = 100.0f;               // �����̵� �ӵ�
    private float endPosX = -540f;                  // ����
    private float offset = 2700f;                   // offset
    private float offset_dist = 540f;               // �����̵� ���� �Ÿ�
    private float pos_y = 793f;                     // y�� ��ġ

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
    }

    private void Update()
    {
        SlideAnim();
        
    }

    // �����̵� �ִϸ��̼��� ���� ��ġ
    public void SetSlideAnim()
    {
        for (int i = 0; i < polaroidCanvasList.Length; i++)
        {
            polaroidCanvasList[i].sprite = polaroidSprites[i];

            // ��ġ ����
            polaroidCanvasList[i].gameObject.transform.position = new Vector3(i * offset_dist, pos_y, 0f);
        }
    }

    // �����̵� �ִϸ��̼�
    public void SlideAnim()
    {
        foreach(var canvas in polaroidCanvasList)
        {
            // �⺻������ �����̵� ����
            canvas.gameObject.transform.position += Vector3.left * slideSpeed * Time.deltaTime;

            // ���� ��ġ���� �̵��ϸ� offset��ŭ x����
            if (canvas.gameObject.transform.position.x < endPosX)
            {
                canvas.gameObject.transform.position += new Vector3(offset, 0f, 0f);
            }
        }    
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

        // �ε� ���� ���� �� ��ġ
        polaroidSprites = polaroidSprites.OrderBy(x => Random.Range(0, 3)).ToArray();
        SetSlideAnim();

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

            // �ε� �ؽ�Ʈ ����
            noticeLoadingText.text = ((percentage / 20)%2 == 0) ? "�ε���.." : "�ε���...";

            yield return null;
        }

        // �ε� �� ������ �ε� ȭ�� ��Ȱ��ȭ

        this.Invoke("IInvoke",3.0f);
            
        
    }
    public void IInvoke()
    {
        
       loadingScene.SetActive(false);
    }
}
