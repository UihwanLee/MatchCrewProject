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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayFailAnimation());
    }

    private IEnumerator PlayFailAnimation()
    {
        yield return null;
    }
}
