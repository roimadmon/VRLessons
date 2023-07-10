using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using Photon.Realtime;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class ManagerNetworkPlayer : MonoBehaviourPunCallbacks, IPunObservable
{
    public static int countOfPlayers = 0;
    [SerializeField] private List<GameObject> _planes;
    [SerializeField] private UnityEvent onOtherPlayerJoin;

    [SerializeField] private PhotonView _photonView;

    // Start is called before the first frame update
    void Start()
    {
        if (_photonView.IsMine)
        {
           Debug.Log("is me");
           if(countOfPlayers != PhotonNetwork.CountOfPlayers) 
               countOfPlayers = PhotonNetwork.CountOfPlayers;
           Debug.Log("id me is: "+_photonView.ViewID);
           
           GameManagerPolice.Instance.AddPlayers(_photonView.ViewID,transform.parent.gameObject);
        }
        else
        {
            
            // Debug.Log("is other - "+(PhotonNetwork.CountOfPlayers));
            // Debug.Log("is other - "+(PhotonNetwork.CountOfPlayers));
            // transform.parent = PlaceHolder.instance.Place[countOfPlayers - 1].transform;
            // transform.parent.position = Vector3.zero;
            // transform.parent.rotation = Quaternion.identity;
            onOtherPlayerJoin?.Invoke();
            GameManagerPolice.Instance.AddPlayers(_photonView.ViewID,transform.parent.gameObject);
        }
        transform.parent.gameObject.name = _photonView.ViewID.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
         
    #region IPunObservable implementation

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        Debug.Log("in OnPhotonSerializeView");
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            foreach (var plan in _planes)
            {
                stream.SendNext(plan.activeSelf);
            }
            // Debug.Log("i am the local client on " +gameObject.name+" - "+ _photonView.ViewID);
            
            
            
        }
        else
        {
            // Network player, receive data
            foreach (var plan in _planes)
            {
                try
                {
                    bool res = (bool) stream.ReceiveNext();
                    plan.SetActive(res);
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                    
                }
                // Debug.Log("i am the other client on " +gameObject.name+" - "+ _photonView.ViewID);
                // Debug.Log(plan.name+" get "+ res);
            }
           
        }
    }

    #endregion
    
    
    
    
    
    #region Photon Callbacks

    /// <summary>
    /// Called when a Photon Player got connected. We need to then load a bigger scene.
    /// </summary>
    /// <param name="other">Other.</param>
    public override void OnPlayerEnteredRoom( Player other  )
    {
        Debug.Log( "OnPlayerEnteredRoom() " + other.NickName); // not seen if you're the player connecting

        if ( PhotonNetwork.IsMasterClient )
        {
            Debug.LogFormat( "OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient ); // called before OnPlayerLeftRoom
           
        }
    }

    /// <summary>
    /// Called when a Photon Player got disconnected. We need to load a smaller scene.
    /// </summary>
    /// <param name="other">Other.</param>
    public override void OnPlayerLeftRoom( Player other  )
    {
        Debug.Log( "OnPlayerLeftRoom() " + other.NickName ); // seen when other disconnects
        Debug.Log( "userid " + other.UserId ); // seen when other disconnects
        // InputActionManager inputManager = GetComponent<InputActionManager>();
        // if (inputManager)
        // {
        //     inputManager.enabled = false;
        //     StartCoroutine(movement());
        // }

        if ( PhotonNetwork.IsMasterClient )
        {
            Debug.LogFormat( "OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient ); // called before OnPlayerLeftRoom
            
        }
    }

    /// <summary>
    /// Called when the local player left the room. We need to load the launcher scene.
    /// </summary>
    public override void OnLeftRoom()
    {
        
    }

    

    #endregion
    
}
