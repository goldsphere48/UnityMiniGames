using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int _count = 0;
    private TextMesh _textMesh;

    void Awake()
    {
        _textMesh = gameObject.GetComponent<TextMesh>();
        StartCoroutine(CountUp());
    }

    public void RestartTimer()
    {
        _textMesh.text = "0";
        _count = 0;
        StopCoroutine(CountUp());
        StartCoroutine(CountUp());
    }

    private IEnumerator CountUp()
    {
        while (GameController.GameState == GameState.Playing)
        {
            _count++;
            _textMesh.text = _count.ToString();
            yield return new WaitForSeconds(1);
        }
    }
}
