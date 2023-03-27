using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    [SerializeField] private bool CurrectAnswer;
    
    public bool answer { get=>CurrectAnswer;  set {CurrectAnswer = value; } }
    // Start is called before the first frame update



    public void OnDestroy()
    {
        try
        {
            Question q = transform.parent.parent.GetComponent<Question>();
            if (q)
                q.ans.Invoke(CurrectAnswer);

        }
        catch (Exception e)
        {
            
        }
    }
   
}
