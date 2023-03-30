using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEditorPlay : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> _objects;
    [SerializeField] private List<GameObject> _TurnOff;
    [SerializeField] private List<GameObject> _TurnOn;
    [SerializeField] private bool hide;
    [SerializeField] private float size;
    void Start()
    {
        #if UNITY_EDITOR
        if(hide)
        {
            foreach (var value in _objects)
            {
                value.transform.localScale = Vector3.one * size;
            }
            foreach (var value in _TurnOff)
            {
                value.SetActive(!hide);
            }
            foreach (var value in _TurnOn)
            {
                value.SetActive(hide);
            }
        }
    #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
