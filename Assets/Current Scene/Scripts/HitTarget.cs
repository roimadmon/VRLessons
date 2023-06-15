using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class HitTarget : MonoBehaviour
{
    [SerializeField] private Answer _answer;
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
            if (_answer.answer)
            {
                Score.Instance.AddScore();
            }
            else
            {
                Score.Instance.RemoveScore();
                Miss.Instance.MissBall();
            }
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