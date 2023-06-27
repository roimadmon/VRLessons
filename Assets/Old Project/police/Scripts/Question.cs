using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


public class Question : MonoBehaviour
{
    public Action<bool,GameObject> ans;
    [SerializeField] private Timer questionTimer;
    [SerializeField] private Timer answerTimer;
    [SerializeField] private TextMeshPro questionText;
    [SerializeField] private TextMeshPro answersExplane;
    [SerializeField] private Transform targetParent;
    [SerializeField] private List<GameObject> targetPrefab;
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private int numberHitsEnable = 2;
    private int currectAnswersNumber;
    [SerializeField] private bool shuffleAnswers;
    [SerializeField] private float timer;
    [SerializeField] private int currectAnswers;
    [SerializeField] private Color currectAnswerColor;
    [SerializeField] private Color wrongAnswerColor;
    [SerializeField] private Rigidbody[] targetsRig;
    [SerializeField] private UnityEvent currectAnswersHit;
    [SerializeField] private UnityEvent wrongAnswersHit;
    [SerializeField] private UnityEvent wrongAnswersHitEnd;
    
    private GameObject currectAnswer;

    public int getCurrectAnswersNumber { get => currectAnswers; }
    // Start is called before the first frame update
    void Start()
    {
        targets = new List<GameObject>();
    }

    public void AnswerStatus(bool ans,GameObject target)
    {
        if(targetsRig == null)
            targetsRig = transform.GetComponentsInChildren<Rigidbody>();
       
        if (ans && numberHitsEnable > 0)
        {
            Score.Instance.AddScore();
            currectAnswersHit?.Invoke();
            numberHitsEnable = 0;
            target.GetComponent<MeshRenderer>().materials[1].color = currectAnswerColor;
            DisableColliders();
            
        }
        else
        {
            if (numberHitsEnable <= 0)
            {
                wrongAnswersHitEnd?.Invoke();
                return;
            }
            target.GetComponent<MeshRenderer>().materials[1].color = wrongAnswerColor;  
            numberHitsEnable--;
            Miss.Instance.MissBall();
            Score.Instance.RemoveScore();
            if (numberHitsEnable > 0)
            {
                wrongAnswersHit?.Invoke();
               
                return;
            }
            DisableColliders();
            wrongAnswersHitEnd?.Invoke();

        }
        
        // Destroy(gameObject);
            // if (ans)
        //     Destroy(gameObject);
        // else
        //     transform.SetSiblingIndex(transform.parent.childCount - 1);
        // ans? transform.SetSiblingIndex(transform.parent.childCount - 1) : Destroy(gameObject);
    }

    public void DisableColliders()
    {
        if(targetsRig.Length == 0)
            targetsRig = transform.GetComponentsInChildren<Rigidbody>();
        
        foreach (var tRigidbody in targetsRig)
        {
            tRigidbody.GetComponent<MeshCollider>().enabled = false;
        }
        
    }
    public void RemoveQuestion()
    {
        FilesManager.instance.RemoveQuestion();
        Destroy(gameObject);
    }
    
    public void GetNextQuestion()
    {
        FilesManager.instance.GetNextQuestion();
        Destroy(gameObject);
    }
    
    private void OnEnable()
    {
        ans += AnswerStatus;
    }
    private void OnDisable()
    {
        ans -= AnswerStatus;
    }
    
    
    

    public void init(questionScript newQuestion)
    {
        questionText.text = newQuestion._question;
        shuffleAnswers = newQuestion.shuffel;
        questionTimer.timeLeft = newQuestion.time;
        answerTimer.timeLeft = newQuestion.timeAns;
        currectAnswers = newQuestion.currectAnswersNumber;
        answersExplane.text = newQuestion._answersExplane;
        currectAnswersNumber = newQuestion.currectAnswersNumber;
        // int index = 0;
        List<int> index = new List<int>();
        for (int i = 0; i < newQuestion._answers.Count; i++)
        {
            index.Add(i);
        }
        
        if (shuffleAnswers)
        {
            index = GetRandumElements(index);
        }

        int j = 0;
        foreach (var answer in newQuestion._answers)
        {
            GameObject targetPref = Instantiate(targetPrefab[index[j++]], targetParent);
            targetPref.name = "not currect";
            
            targetPref.GetComponentInChildren<Answer>().answer = currectAnswersNumber > 0;
            currectAnswersNumber--;
            TextMeshPro answerText = targetPref.GetComponentInChildren<TextMeshPro>();
            answerText.text = answer;
            targets.Add(targetPref);
        }

        targets[0].name = "currect";
        if (shuffleAnswers)
        {

            // targets = GetRandumElements(targets);
            // for (int i = 0; i < targets.Count; i++)
            // {
            //     targets[i].transform.SetSiblingIndex(i);
            // }
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



    // void disableTarget(bool b)
    // {
    //     if(FilesManager.instance._init)
    //         return;
    //     
    //     if (b)
    //         currectAnswers--;
    //    
    //
    //     if (currectAnswers == 0)
    //     {
    //         Debug.Log("you find all answers");
    //         Debug.Log("child number = " + transform.GetSiblingIndex());
    //         ManagerQuestions.instance.init();
    //         Destroy(this.gameObject);
    //     }
    //     
    // }
    //
    
}


