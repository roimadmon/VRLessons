using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolder : MonoBehaviour
{
    public static PlaceHolder instance;
    [SerializeField] private List<Transform> _locations;

    public List<Transform> Place
    {
        get => _locations;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _locations.Add(transform.GetChild(i).GetComponent<Transform>());
        }
    }
}