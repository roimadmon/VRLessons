using System;
using System.Collections;
using System.Collections.Generic;
using Autohand.Demo;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    
    [SerializeField] private TextChanger _scoreTxt;
    [SerializeField] private TextChanger _answerTxt;
    [SerializeField] private TextChanger _scorePlayerTxt;
    [SerializeField] private int _scorePoint = 3;
    [SerializeField] private int _wrong = -1;
    private int _score;
    private int _answer;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        
        Instance = this;
        
    }

    

    // Start is called before the first frame update
    void Start()
    {
        RestartGame();
    }

    public void RestartGame()
    {
        _score = 0;
        _answer = 0;
        updateUi();
    }
    
    public void AddScore()
    {
        _score += _scorePoint;
        _answer++;
        updateUi();
    }

    public void RemoveScore()
    {
        _score += _wrong;
        if (_score < 0)
            _score = 0;

        updateUi();
    }

    void updateUi()
    {
        _scoreTxt.UpdateTextScore(_score);
        _scorePlayerTxt.UpdateTextScore(_score);
        _answerTxt.UpdateTextScore(_answer);
    }


}
