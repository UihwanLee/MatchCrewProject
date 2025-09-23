using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 실패 문구를 역동적으로 애니메이션하는 클래스
/// </summary>
public class FailTextAnim : MonoBehaviour
{
    [SerializeField] private Text[] letters;

    [SerializeField] private float baseDelay = 0.1f;
    [SerializeField] private float randomDelay = 0.05f;
    [SerializeField] private float fadeDuration = 1.5f;
    [SerializeField] private float moveDistance = 2.0f;
    [SerializeField] private float rotationAngle = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        float delay = 0f;

        // 코루틴을 사용하여 한 글자 씩 내려가는 연출 구현
        for(int i=0; i<letters.Length; i++)
        {
            float temp = baseDelay + Random.Range(0f, randomDelay);
            delay += temp;

            StartCoroutine(PlayFailAnimation(letters[i], i * delay));
        }
    }

    private IEnumerator PlayFailAnimation(Text letter, float delay)
    {
        // 초반 딜레이 시작
        yield return new WaitForSeconds(delay);

        RectTransform rectTransform = letter.GetComponent<RectTransform>();
        Color orginColor = letter.color;
        rectTransform.localRotation = Quaternion.identity;

        // 처음에는 투명하게 세팅
        letter.color = new Color(orginColor.r, orginColor.g, orginColor.b, 0f);
        rectTransform.anchoredPosition += new Vector2(0f, moveDistance);

        // 시간에 따른 투명도 조정
        float elapsed = 0f;
        Vector2 startPos = rectTransform.anchoredPosition;
        Vector2 endPos = startPos - new Vector2(0f, moveDistance);

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
