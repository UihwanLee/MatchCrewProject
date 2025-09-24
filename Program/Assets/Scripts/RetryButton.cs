using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        // 리트라이 버튼을 눌렀을 때 난이도 1부터 다시 시작
        LoadingManager.Instance.LoadScene("StageFail");
    }
}
