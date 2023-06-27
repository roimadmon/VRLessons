using System;

using UnityEngine;

public class Answer : MonoBehaviour
{
    [SerializeField] private bool CurrectAnswer;
    [SerializeField] private GameObject target;
    
    public bool answer { get=>CurrectAnswer;  set {CurrectAnswer = value; } }
    // Start is called before the first frame update
    


    public void OnHit()
    {
        try
        {
            Question q = transform.parent.parent.parent.GetComponent<Question>();
            if (q)
                q.ans.Invoke(CurrectAnswer,target);
            
            

        }
        catch (Exception e)
        {
            
        }
    }
   
}

