using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKJoint : MonoBehaviour
{
    public IKJoint m_child;

    public IKJoint GetChild()
    {
        return m_child;
    }

    public void Rotate(float _angle)
    {
        transform.Rotate(Vector3.right*_angle);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
