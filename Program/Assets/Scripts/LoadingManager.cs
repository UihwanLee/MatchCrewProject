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
    public GameObject loadingScene;                 // 로딩 화면
    public Slider progressBar;                      // 로딩 진행 바
    public Text progressText;                       // 로딩 퍼센트
    public Text noticeLoadingText;                  // 로딩중 텍스트
    public Image loadingImg;                        // 폴라로이드 이미지

    [Header("Team List")]
    public Sprite[] teamList;                        // 폴라로이드 사진 리스트

    private bool isLoading;
    private int listIdx;                             // 리스트 인덱스


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
        // 변수 초기화
        isLoading = false;
        loadingScene.SetActive(false);

        // 폴라로이드 변경 함수 Invoke
        listIdx = 0;
        InvokeRepeating("LoadingAnim", 0f, 1f);
    }

    // 폴라로이드 사진 슬라이드 애니메이션 플레이
    public void ChangeSlideImage()
    {
        // 로딩중이 아닐 때는 애니메이션 플레이 X
        //if (!isLoading) return;

        // 리스트 예외처리
        if (teamList == null) return;

        listIdx = listIdx % teamList.Length;

        // 폴라로이드 사진 변경
        loadingImg.sprite = teamList[listIdx];

        // 로딩 텍스트 변경
        noticeLoadingText.text = (listIdx % 2 == 0) ? "로딩중.." : "로딩중...";

        listIdx++;
    }

    // Scene 인덱스로 로딩
    public void LoadScene(int sceneIndex)
    {
        // 이미 로딩 중일 시 예외처리
        if(isLoading) return;

        // 로딩화면 활성화
        if (loadingScene != null) loadingScene.SetActive(true);

        // 로딩 시작
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        StartCoroutine(LoadAsynchronously(operation));
    }

    // Scene 이름으로 로딩
    public void LoadScene(string sceneName)
    {
        // 이미 로딩 중일 시 예외처리
        if (isLoading) return;

        // 로딩화면 활성화
        if (loadingScene != null) loadingScene.SetActive(true);

        // 로딩 사진 셔플
        teamList = teamList.OrderBy(x=>Random.Range(0, 3)).ToArray();

        // 로딩 시작
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        StartCoroutine(LoadAsynchronously(operation));
    }

    // 로딩 프로세스
    private IEnumerator LoadAsynchronously(AsyncOperation operation)
    {
        while (!operation.isDone)
        {
            // 로딩 진행 값 (0~1) 값으로 반환
            float progress = Mathf.Clamp01(operation.progress / .9f);

            // 100을 곱해서 퍼센트 구하기
            float percentage = progress * 100f;

            // 진행 바 업데이트
            if (progressBar != null)
                progressBar.value = progress;

            // 퍼센트 텍스트 업데이트
            if (progressText != null)
                progressText.text = percentage.ToString("0") + "%";

            yield return null;
        }

        // 로딩 다 끝나면 로딩 화면 비활성화
        if(loadingScene != null) loadingScene.SetActive(false);
    }

}
