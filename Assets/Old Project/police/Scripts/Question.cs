using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class Question : MonoBehaviour
{
    public Action<bool> ans;
    
    [SerializeField] private TextMeshPro questionText;
    [SerializeField] private Transform targetParent;
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private List<GameObject> targets;
    private int currectAnswersNumber;
    [SerializeField] private bool shuffleAnswers;
    [SerializeField] private float timer;
    [SerializeField] private int currectAnswers;
    
    private GameObject currectAnswer;

    public int getCurrectAnswersNumber { get => currectAnswers; }
    // Start is called before the first frame update
    void Start()
    {
        targets = new List<GameObject>();
    }
    
    
    private void OnEnable()
    {
        ans += disableTarget;
    }
    private void OnDisable()
    {
        ans -= disableTarget;
    }
    
    
    

    public void init(questionScript newQuestion)
    {
        questionText.text = newQuestion._question;
        shuffleAnswers = newQuestion.shuffel;
        timer = newQuestion.time;
        currectAnswers = newQuestion.currectAnswersNumber;
        currectAnswersNumber = newQuestion.currectAnswersNumber;
        int index = 0;
        foreach (var answer in newQuestion._answers)
        {
            GameObject targetPref = Instantiate(targetPrefab, targetParent);
            targetPref.name = targetPref.name + " " + index++;
            targetPref.GetComponent<Answer>().answer = currectAnswersNumber > 0;
            currectAnswersNumber--;
            TextMeshPro answerText = targetPref.GetComponentInChildren<TextMeshPro>();
            answerText.text = answer;
            targets.Add(targetPref);
        }
        
        if (shuffleAnswers)
        {

            targets = GetRandumElements(targets);
            for (int i = 0; i < targets.Count; i++)
            {
                targets[i].transform.SetSiblingIndex(i);
            }
        }

    }
  


    List<T> GetRandumElements<T>(List<T> inputList)
    {
        var count = inputList.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i) {
            var r = Random.Range(i, count);
            var tmp = inputList[i];
            inputList[i] = inputList[r];
            inputList[r] = tmp;
        }

        return inputList;
    }



    void disableTarget(bool b)
    {
        if(FilesManager.instance._init)
            return;
        
        if (b)
            currectAnswers--;
       

        if (currectAnswers == 0)
        {
            Debug.Log("you find all answers");
            Debug.Log("child number = " + transform.GetSiblingIndex());
            ManagerQuestions.instance.init();
            Destroy(this.gameObject);
        }
        
    }
    
    
}


