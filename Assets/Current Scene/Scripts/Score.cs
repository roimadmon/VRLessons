using System.Collections;
using System.Collections.Generic;
using Autohand.Demo;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextChanger _scoreTxt;
    [SerializeField] private TextChanger _answerTxt;
    [SerializeField] private TextChanger _scorePlayerTxt;
    [SerializeField] private int _scorePoint = 3;
    [SerializeField] private int _wrong = -1;
    private int _score;
    private int _answer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _answer = 0;
    }

    public void AddScore()
    {
        _score += _scorePoint;
        _answer++;
        _scoreTxt.UpdateTextint(_score);
        _scorePlayerTxt.UpdateTextint(_score);
        _answerTxt.UpdateTextint(_answer);
    }
    public void RemoveScore()
    {
        _score += _wrong;
        if (_score < 0)
            _score = 0;
        _scoreTxt.UpdateTextint(_score);
        _scorePlayerTxt.UpdateTextint(_score);
    }

    
}
