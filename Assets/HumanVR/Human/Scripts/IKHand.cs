using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKHand : MonoBehaviour
{

    [SerializeField] private Transform followOject;
    // [SerializeField] private float followSpeed = 30f;
    // [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotarionOffset;

    private Transform _followTarget;
    // private Rigidbody _body;
    // Start is called before the first frame update
    void Start()
    {
        _followTarget = followOject.transform;
        // _body = GetComponent<Rigidbody>();
        // _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        // _body.interpolation = RigidbodyInterpolation.Interpolate;
        // _body.mass = 20f;

        // _body.position = _followTarget.position ;
        // _body.rotation = _followTarget.rotation  * Quaternion.Euler(rotarionOffset);;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followOject.position + positionOffset;
        transform.rotation = followOject.rotation * Quaternion.Euler(rotarionOffset);
        // _body.velocity  = Vector3.zero;
        // PhysicsMove();
    }

    // private void PhysicsMove()
    // {
        // Vector3 positionWithOffset = _followTarget.TransformPoint(positionOffset);
        // float distance = Vector3.Distance(positionWithOffset, transform.position);
        // _body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);
        
        
        // Quaternion rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotarionOffset);
        // Quaternion q = rotationWithOffset * Quaternion.Inverse(_body.rotation);
        // q.ToAngleAxis(out float angle, out Vector3 axis);
        // _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);

    // }
}
