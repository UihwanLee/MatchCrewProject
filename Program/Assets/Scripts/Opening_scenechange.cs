using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpiralCameraTransition : MonoBehaviour
{
    public Camera cam;                 // 카메라
    public CanvasGroup fadePanel;      // 검은색 Panel
    public float duration = 2f;        // 전환 시간
    public string nextScene = "StartScene";

    void Start()
    {
        fadePanel.alpha = 0; // 시작할 때 투명
    }

    public void StartTransition()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        float t = 0;
        Quaternion startRot = cam.transform.rotation;
        Quaternion endRot = cam.transform.rotation * Quaternion.Euler(0, 0, 360); // 360도 회전

        while (t < 1)
        {
            t += Time.deltaTime / duration;

            // 카메라 회전
            cam.transform.rotation = Quaternion.Slerp(startRot, endRot, t);

            // 페이드 아웃
            fadePanel.alpha = t;

            yield return null;
        }

        SceneManager.LoadScene(nextScene);
    }
}
