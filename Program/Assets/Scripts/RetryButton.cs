using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        // ��Ʈ���� ��ư�� ������ �� ���̵� 1���� �ٽ� ����
        LoadingManager.Instance.LoadScene("StageFail");
    }
}
