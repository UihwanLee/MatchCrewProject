using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 실패 문구를 역동적으로 애니메이션하는 클래스
/// </summary>
public class FailTextAnim : MonoBehaviour
{
    [Header("Letter Setting")]
    public Image[] letters;                     // 실패 문구

    [Header("Animation Setting")]
    public float baseDelay = 0.1f;              // 기본 딜레이
    public float randomDelay = 0.05f;           // 랜덤 딜레이
    public float fadeDuration = 0.8f;           // 연출 시간
    public float moveDistance = 60f;            // 내려오는 거리
    public float rotationAngle = 10.0f;         // 회전 각도

    public AudioClip sfx_fail;                  // 실패 사운드
    public AudioSource audioSource;             // 오디오 소스

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        float delay = 0f;

        // 코루틴을 사용하여 한 글자 씩 내려가는 연출 구현
        for(int i=0; i<letters.Length; i++)
        {
            // 처음에는 투명하게 세팅
            Color orginColor = letters[i].color;
            letters[i].color = new Color(orginColor.r, orginColor.g, orginColor.b, 0f);
            RectTransform rectTransform = letters[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition += new Vector2(0f, moveDistance);
            rectTransform.localRotation = Quaternion.identity;

            float temp = baseDelay + Random.Range(0f, randomDelay);
            delay += temp;

            StartCoroutine(PlayFailAnimation(letters[i], i * delay, rectTransform, orginColor));
        }

        // 실패 효과음 재생
        audioSource.clip = sfx_fail;
        audioSource.Play();
    }

    private IEnumerator PlayFailAnimation(Image letter, float delay, RectTransform rectTransform, Color orginColor)
    {
        // 초반 딜레이 시작
        yield return new WaitForSeconds(delay);

        // 시간에 따른 투명도 조정
        float elapsed = 0f;
        Vector2 startPos = rectTransform.anchoredPosition;

        // 기울인 위치에 따라 위치 조정
        Vector2 rotatedOffset = Quaternion.Euler(0f, 0f, rotationAngle) * Vector2.down * moveDistance;
        Vector2 endPos = startPos + rotatedOffset;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / fadeDuration);

            // 투명도 증가
            letter.color = new Color(orginColor.r, orginColor.g, orginColor.b, alpha);

            // 글자 회전
            float rot = Mathf.Lerp(0f, rotationAngle, alpha);
            rectTransform.localRotation = Quaternion.Euler(0f, 0f, rot);

            // 위치 조정
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, alpha);

            yield return null;
        }
    }
}
