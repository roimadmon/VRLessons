using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class HitTarget : MonoBehaviour
{
    [SerializeField] private GameObject holeGameObject;
    [SerializeField] private int countHit = 2;
    public UnityEvent OnHit;
    public UnityEvent OnEnd;

    public void Hit(Vector3 hitPoint)
    {
        if (countHit > 0)
        {
            if(holeGameObject)
                Instantiate(holeGameObject, hitPoint, quaternion.identity, transform);
            OnHit?.Invoke();
            countHit--;
            if(countHit == 0)
                OnEnd?.Invoke();
        }
        else
        {
            OnEnd?.Invoke();
        }
    }
}