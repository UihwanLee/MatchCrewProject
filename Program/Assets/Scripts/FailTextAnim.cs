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
