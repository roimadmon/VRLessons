using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectGamePlay : MonoBehaviour
{
    [SerializeField] private UnityEvent single;
    [SerializeField] private UnityEvent Multi;



    public void SetSinglePlayer(bool state)
    {
        if(state)
            single?.Invoke();
    }
    
    public void SetMultiPlayer(bool state)
    {
        if(state)
            Multi?.Invoke();
    }
}
