using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���� ������ ���������� �ִϸ��̼��ϴ� Ŭ����
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

        // �ڷ�ƾ�� ����Ͽ� �� ���� �� �������� ���� ����
        for(int i=0; i<letters.Length; i++)
        {
            float temp = baseDelay + Random.Range(0f, randomDelay);
            delay += temp;

            StartCoroutine(PlayFailAnimation(letters[i], i * delay));
        }
    }

    private IEnumerator PlayFailAnimation(Text letter, float delay)
    {
        // �ʹ� ������ ����
        yield return new WaitForSeconds(delay);

        RectTransform rectTransform = letter.GetComponent<RectTransform>();
        Color orginColor = letter.color;
        rectTransform.localRotation = Quaternion.identity;

        // ó������ �����ϰ� ����
        letter.color = new Color(orginColor.r, orginColor.g, orginColor.b, 0f);
        rectTransform.anchoredPosition += new Vector2(0f, moveDistance);

        // �ð��� ���� ���� ����
        float elapsed = 0f;
        Vector2 startPos = rectTransform.anchoredPosition;
        Vector2 endPos = startPos - new Vector2(0f, moveDistance);

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / fadeDuration);

            // ���� ����
            letter.color = new Color(orginColor.r, orginColor.g, orginColor.b, alpha);

            // ���� ȸ��
            float rot = Mathf.Lerp(0f, rotationAngle, alpha);
            rectTransform.localRotation = Quaternion.Euler(0f, 0f, rot);

            // ��ġ ����
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, alpha);

            yield return null;
        }
    }
}
