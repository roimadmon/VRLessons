using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyClone : MonoBehaviour
{
    [SerializeField] private float timeRemove = 3f;
    private void OnEnable()
    {
        Invoke("DestroyObject",timeRemove);
        
    }


    void DestroyObject()
    {
        Destroy(gameObject);
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
