using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���� ������ ���������� �ִϸ��̼��ϴ� Ŭ����
/// </summary>
public class FailTextAnim : MonoBehaviour
{
    [Header("Letter Setting")]
    public Image[] letters;                     // ���� ����

    [Header("Animation Setting")]
    public float baseDelay = 0.1f;              // �⺻ ������
    public float randomDelay = 0.05f;           // ���� ������
    public float fadeDuration = 0.8f;           // ���� �ð�
    public float moveDistance = 60f;            // �������� �Ÿ�
    public float rotationAngle = 10.0f;         // ȸ�� ����

    public AudioClip sfx_fail;                  // ���� ����
    public AudioSource audioSource;             // ����� �ҽ�

    public Button RetryButton;                  // Retry ��ư

    private float fivot_letter = -200.0f;       // ���� ��ġ pivot
    private float offset_letter = 80.0f;        // ���� ��ġ offset

    private void Awake()
    {
        // ����� �ʱ�ȭ
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        // Retry ��ư ���� �ʱ�ȭ
        RetryButton.GetComponent<Animator>().SetBool("isAnimDone", false);

        float delay = 0f;

        // �ڷ�ƾ�� ����Ͽ� �� ���� �� �������� ���� ����
        for(int i=0; i<letters.Length; i++)
        {
            // ó������ �����ϰ� ����
            Color orginColor = letters[i].color;
            letters[i].color = new Color(orginColor.r, orginColor.g, orginColor.b, 0f);

            // ��ġ ����
            RectTransform rectTransform = letters[i].GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2((fivot_letter + (offset_letter * i)), 0f);
            rectTransform.anchoredPosition += new Vector2(0f, moveDistance);
            rectTransform.localRotation = Quaternion.identity;

            float temp = baseDelay + Random.Range(0f, randomDelay);
            delay += temp;

            StartCoroutine(PlayFailAnimation(letters[i], i * delay, rectTransform, orginColor));
        }

        // ���� ȿ���� ���
        audioSource.clip = sfx_fail;
        audioSource.Play();
    }

    private IEnumerator PlayFailAnimation(Image letter, float delay, RectTransform rectTransform, Color orginColor)
    {
        // �ʹ� ������ ����
        yield return new WaitForSeconds(delay);

        // �ð��� ���� ���� ����
        float elapsed = 0f;
        Vector2 startPos = rectTransform.anchoredPosition;

        // ����� ��ġ�� ���� ��ġ ����
        Vector2 rotatedOffset = Quaternion.Euler(0f, 0f, rotationAngle) * Vector2.down * moveDistance;
        Vector2 endPos = startPos + rotatedOffset;

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

        //yield return new WaitForSeconds(3f);

        // Retry ��ư �ִϸ��̼� ���� ����
        RetryButton.GetComponent<Animator>().SetBool("isAnimDone", true);
    }
}
