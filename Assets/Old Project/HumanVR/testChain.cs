using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;

public class testChain : MonoBehaviour
{
   //  private MultiPositionConstraint mpc;
   
   [SerializeField] private Transform partBodyStart;
   [SerializeField] private Transform target;
   
   [SerializeField] private Transform partBodyStresh;
   [SerializeField ,Range(0,0.3f)] private float _maxStretch = 0.2f;
   private float stretch = 0;
   
   private float initDictance;
   
    // Start is called before the first frame update
    void Start()
    {
        initDictance = Vector3.Distance(partBodyStart.position, target.position);
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (Vector3.Distance(partBodyStart.position, target.position) > initDictance)
        {
            stretch = Vector3.Distance(partBodyStart.position, target.position) - initDictance;
            partBodyStresh.position += partBodyStresh.up * Mathf.Min(stretch,_maxStretch);
            
        }
        else
        {
            stretch = 0;

        }
    }


}
