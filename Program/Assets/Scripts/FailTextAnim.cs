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
    [SerializeField] private float delay = 0.5f;
    [SerializeField] private float fadeDuration = 1.5f;
    [SerializeField] private float moveDistance = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayFailAnimation());
    }

    private IEnumerator PlayFailAnimation()
    {
        // �ڷ�ƾ�� ����Ͽ� �� ���� �� �������� ���� ����
        foreach(var letter in letters)
        {
            RectTransform rectTransform = letter.GetComponent<RectTransform>();
            Color orginColor = letter.color;

            // ó������ �����ϰ� ����
            letter.color = new Color(orginColor.r, orginColor.g, orginColor.b, 0f);
            rectTransform.anchoredPosition += new Vector2(0f, moveDistance);

            // �ð��� ���� ���� ����
            float elapsed = 0f;
            Vector2 startPos = rectTransform.anchoredPosition;
            Vector2 endPos = startPos - new Vector2(0f, moveDistance);

            while(elapsed < fadeDuration)
            {
                elapsed += Time.deltaTime;
                float alpha = Mathf.Clamp01(elapsed / fadeDuration);

                // ���� ����
                letter.color = new Color(orginColor.r, orginColor.g, orginColor.b, alpha);

                // ��ġ ����
                rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, alpha);

                yield return null;
            }

            // ���� ���ڴ� ���� �ð� �� ����
            yield return new WaitForSeconds(delay);
        }
    }
}
