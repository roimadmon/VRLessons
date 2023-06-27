using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(fileName = "questions", menuName = "ScriptableObjects/questions", order = 1)]
//
// public class questions : ScriptableObject
// {
//     // public string _colorName;
//     public List<questionScript> question;
// }

[Serializable]
public class questionScript
{
    public float time;
    public float timeAns;
    public bool shuffel;
    public string _question;
    public string _answersExplane;
    public List<string> _answers;
    public int currectAnswersNumber;
    public int numberQuestion;
    public questionScript()
    {
        _answers = new List<string>();
    }
}
