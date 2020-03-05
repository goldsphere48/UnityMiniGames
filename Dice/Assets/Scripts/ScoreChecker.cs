using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreChecker : MonoBehaviour
{
    [SerializeField] private GameObject[] _sides;
    public UnityEvent OnTopSideChanged;
    public string CurrentScore => _currentScore;

    private int _topSideIndex = 1;
    private string _currentScore = "1";

    private void Start()
    {
        StartCoroutine(CalculateTopSide());
    }

    private IEnumerator CalculateTopSide()
    {
        while (true)
        {
            float maxY = -10;
            int index = 0;
            for (int i = 0; i < _sides.Length; ++i)
            {
                if (_sides[i].transform.position.y > maxY)
                {
                    maxY = _sides[i].transform.position.y;
                    index = i;
                }
            }
            if (_topSideIndex != index)
            {
                _topSideIndex = index;
                _currentScore = _sides[index].name;
                OnTopSideChanged?.Invoke();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
