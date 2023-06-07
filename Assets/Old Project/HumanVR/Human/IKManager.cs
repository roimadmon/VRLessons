using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : MonoBehaviour
{
    public IKJoint m_root;

    public IKJoint m_end;

    public GameObject m_target;

    public float m_threshold = 0.05f;
    public float m_rate = 10f;
    public int m_steps = 20; 
    public int maxJoint = 5; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_steps; i++)
        {

            if (GetDistance(m_end.transform.position, m_target.transform.position) > m_threshold)
            {
                int j = 0;
                IKJoint current = m_root;
                while (current != null && j<maxJoint)
                {
                    float slope = CalculateSlope(current);
                    current.Rotate(-slope * m_rate);
                    current = current.GetChild();
                    j++;
                }
            }
            }
            // if (GetDistance(m_end.transform.position, m_target.transform.position) > m_threshold)
            // {
                // float slope = CalculateSlope(m_root);
                // m_root.Rotate(-slope * m_rate);
            // }
    }

    float CalculateSlope(IKJoint _joint)
    {
        float deltaTheta = 0.01f;
        float distance1 = GetDistance(m_end.transform.position, m_target.transform.position);
        _joint.Rotate(deltaTheta);
        float distance2 = GetDistance(m_end.transform.position, m_target.transform.position);
        _joint.Rotate(-deltaTheta);
        return (distance2 - distance1) / deltaTheta;
    }
    float GetDistance(Vector3 _point1, Vector3 _point2)
    {
        return Vector3.Distance(_point1, _point2);
    }
}
