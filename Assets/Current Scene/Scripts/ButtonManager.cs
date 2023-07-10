using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
  
    // Start is called before the first frame update
    private void OnEnable()
    {
        transform.parent.GetComponent<Button>()?.onClick.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
