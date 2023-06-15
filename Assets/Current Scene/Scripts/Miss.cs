using System;
using UnityEngine;
using UnityEngine.Events;

public class Miss : MonoBehaviour
{
    [SerializeField] private int countHit = 2;
    public UnityEvent OnEnd;
    public UnityEvent OnMiss;
    
    public static Miss Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void MissBall()
    {
        if (countHit > 0)
        {
            countHit--;
            if(countHit>0)
                OnMiss?.Invoke();
            if(countHit == 0)
                Invoke("StartEvent",1);
        }
        else
        {
            OnEnd?.Invoke();
        }
    }

    void StartEvent()
    {
        OnEnd?.Invoke();
    }
}
