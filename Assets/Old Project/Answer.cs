using System;

using UnityEngine;

public class Answer : MonoBehaviour
{
    [SerializeField] private bool CurrectAnswer;
    [SerializeField] private GameObject target;
    [SerializeField] private Color currectAnswerColor;
    [SerializeField] private Color wrongAnswerColor;
    public bool answer { get=>CurrectAnswer;  set {CurrectAnswer = value; } }
    // Start is called before the first frame update
    


    public void OnHit()
    {
        try
        {
            Debug.Log("hit");
            Question q = transform.parent.parent.parent.GetComponent<Question>();
            if (q)
                q.ans.Invoke(CurrectAnswer,target);

            if (CurrectAnswer)
            {
                Debug.Log("in");
                target.GetComponentInParent<MeshRenderer>().materials[1].color = currectAnswerColor;
                
            }
            else
            {
                Debug.Log("out");
                target.GetComponentInParent<MeshRenderer>().materials[1].color = wrongAnswerColor;
            }

        }
        catch (Exception e)
        {
            
        }
    }
   
}

