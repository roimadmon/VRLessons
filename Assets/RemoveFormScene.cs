using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class RemoveFormScene : MonoBehaviour
{
    [SerializeField] private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if(!photonView.IsMine)
            Destroy(gameObject);
    }

}