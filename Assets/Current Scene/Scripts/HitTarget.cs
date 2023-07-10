using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class HitTarget : MonoBehaviour
{
    [SerializeField] private GameObject holeGameObject;
    [SerializeField] private int countHit = 20;
    public UnityEvent OnHit;
    public UnityEvent OnHitEnd;
    [SerializeField] private bool debugHit;
    public void Hit(Vector3 hitPoint)
    {
        countHit--;
        if(holeGameObject)
                Instantiate(holeGameObject, hitPoint, quaternion.identity, transform.parent);
            OnHit?.Invoke();
           
        if(countHit<=0)
            OnHitEnd?.Invoke();
        
    }

    private void Update()
    {
        if (debugHit)
        {
            Hit(new Vector3(-0.266f, 0.9914f, 0.0102f));
            debugHit = false;
        }
    }
}