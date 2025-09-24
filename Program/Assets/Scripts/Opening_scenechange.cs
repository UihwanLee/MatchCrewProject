using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpiralCameraTransition : MonoBehaviour
{
    public Camera cam;                 // ī�޶�
    public CanvasGroup fadePanel;      // ������ Panel
    public float duration = 2f;        // ��ȯ �ð�
    public string nextScene = "StartScene";

    void Start()
    {
        fadePanel.alpha = 0; // ������ �� ����
    }

    public void StartTransition()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        float t = 0;
        Quaternion startRot = cam.transform.rotation;
        Quaternion endRot = cam.transform.rotation * Quaternion.Euler(0, 0, 360); // 360�� ȸ��

        while (t < 1)
        {
            t += Time.deltaTime / duration;

            // ī�޶� ȸ��
            cam.transform.rotation = Quaternion.Slerp(startRot, endRot, t);

            // ���̵� �ƿ�
            fadePanel.alpha = t;

            yield return null;
        }

        SceneManager.LoadScene(nextScene);
    }
}
