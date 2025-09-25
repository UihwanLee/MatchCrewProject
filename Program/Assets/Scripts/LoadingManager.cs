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

    [Header("Polaroid List")]
    public Sprite[] polaroidSprites;                // 폴라로이드 사진 리스트
    public Image[] polaroidCanvasList;              // 폴라로이드 캔버스 리스트

    private bool isLoading;                         // 로딩 확인 변수

    public float slideSpeed = 100.0f;               // 슬라이드 속도
    private float endPosX = -540f;                  // 끝점
    private float offset = 2700f;                   // offset
    private float offset_dist = 540f;               // 슬라이드 사이 거리
    private float pos_y = 793f;                     // y축 위치

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
    }

    private void Update()
    {
        SlideAnim();
        
    }

    // 슬라이드 애니메이션을 위한 배치
    public void SetSlideAnim()
    {
        for (int i = 0; i < polaroidCanvasList.Length; i++)
        {
            polaroidCanvasList[i].sprite = polaroidSprites[i];

            // 위치 세팅
            polaroidCanvasList[i].gameObject.transform.position = new Vector3(i * offset_dist, pos_y, 0f);
        }
    }

    // 슬라이드 애니메이션
    public void SlideAnim()
    {
        foreach(var canvas in polaroidCanvasList)
        {
            // 기본적으로 슬라이드 상태
            canvas.gameObject.transform.position += Vector3.left * slideSpeed * Time.deltaTime;

            // 일정 위치까지 이동하면 offset만큼 x증가
            if (canvas.gameObject.transform.position.x < endPosX)
            {
                canvas.gameObject.transform.position += new Vector3(offset, 0f, 0f);
            }
        }    
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

        // 로딩 사진 셔플 및 배치
        polaroidSprites = polaroidSprites.OrderBy(x => Random.Range(0, 3)).ToArray();
        SetSlideAnim();

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

            // 로딩 텍스트 변경
            noticeLoadingText.text = ((percentage / 20)%2 == 0) ? "로딩중.." : "로딩중...";

            yield return null;
        }

        // 로딩 다 끝나면 로딩 화면 비활성화

        this.Invoke("IInvoke",3.0f);
            
        
    }
    public void IInvoke()
    {
        
       loadingScene.SetActive(false);
    }
}
