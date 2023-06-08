using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManagerQuestions : MonoBehaviour
{
    public static ManagerQuestions instance;
    public Action<bool> ans;
    [SerializeField] private List<GameObject> child;
    [SerializeField] int _numberQuestion;
    [SerializeField] int _numberAnswersCurrect;
    [SerializeField] private UnityEvent done;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        
        instance = this;
        
    }

    private void Start()
    {
        child = new List<GameObject>();
        // if(!FilesManager.instance._init)
        //     StartCoroutine(UpdateList());
    }

    private void OnEnable()
    {
        ans += test;
    }
 private void OnDisable()
    {
        ans -= test;
    }

    void test(bool b)
    {
       
    }

    
    public void init()
    {
        // instance._numberQuestion = numberQuestion;
        // instance._numberAnswersCurrect = currectAnswers;
        StartCoroutine(UpdateList());
    }


    IEnumerator UpdateList()
    {
        yield return new WaitForSeconds(0.3f);
        if (instance.child.Count > 0)
        {
            instance.child.Clear();
        }
        
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).gameObject!=null)
                instance.child.Add(transform.GetChild(i).gameObject);
        }
        
        for (int i = 0; i < child.Count; i++)
        {
            child[i].SetActive(false);
            
        }
        if (child.Count > 0)
        {
            child[0].SetActive(true);
            _numberAnswersCurrect = child[0].GetComponent<Question>().getCurrectAnswersNumber;
        }
        else
        {
            done.Invoke();
        }
    }
}
