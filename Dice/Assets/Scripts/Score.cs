using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    private ScoreChecker[] _scoreCheckers;
    private Text _text;

    public void InitializeScore()
    {
        _text = GetComponent<Text>();
        _scoreCheckers = FindObjectsOfType<ScoreChecker>();

        foreach (var scoreChecker in _scoreCheckers)
        {
            scoreChecker.OnTopSideChanged.AddListener(UpdateScore);
        }
    }

    private string GetScore()
    {
        int sum = 0;
        for (int i = 0; i < _scoreCheckers.Length; ++i)
        {
            sum += int.Parse(_scoreCheckers[i].CurrentScore);
        }
        Debug.Log(sum.ToString());
        return sum.ToString();
    }

    public void UpdateScore()
    {
        _text.text = GetScore();
    }
}
