// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Launcher.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking Demos
// </copyright>
// <summary>
//  Used in "PUN Basic tutorial" to handle typical game management requirements
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Photon.Pun.Demo.Cockpit;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Realtime;

namespace Photon.Pun.Demo.PunBasics
{
	#pragma warning disable 649

	/// <summary>
	/// Game manager.
	/// Connects and watch Photon Status, Instantiate Player
	/// Deals with quiting the room and the game
	/// Deals with level loading (outside the in room synchronization)
	/// </summary>
	public class GameManagerPolice : MonoBehaviourPunCallbacks
    {

		#region Public Fields

		static public GameManagerPolice Instance;

		#endregion

		#region Private Fields


        [Tooltip("The prefab to use for representing the player")]
        [SerializeField]
        private GameObject playerPrefab;
        [SerializeField]
        private string lobyNameScene;

        [SerializeField] private Vector3 _offset;
        private Dictionary<int, GameObject> _players;
        public bool isAdmin = false;
        #endregion

        #region MonoBehaviour CallBacks

        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during initialization phase.
        /// </summary>
        void Start()
		{
			Instance = this;
			// _offset = new Vector3(-0.5f, 1.5f, 0.5f);
			// in case we started this demo with the wrong scene being active, simply load the menu scene
			if (!PhotonNetwork.IsConnected)
			{
				SceneManager.LoadScene(lobyNameScene);
				return;
			}
			
			_players = new Dictionary<int, GameObject>();
			if (playerPrefab == null) { // #Tip Never assume public properties of Components are filled up properly, always check and inform the developer of it.
			
				Debug.LogError("<Color=Red><b>Missing</b></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
			} else {
				Debug.Log(PlayerManager.LocalPlayerInstance);
				if (PlayerManager.LocalPlayerInstance==null)
				{
				    Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);

					// we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
					PhotonNetwork.Instantiate(this.playerPrefab.name, PlaceHolder.instance.Place[PhotonNetwork.CountOfPlayers-1].transform.position, Quaternion.identity,0);
					
					if (PhotonNetwork.IsMasterClient)
					{
						Debug.Log("in master");
					}
					
				}else{

					Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
				}


			}

		}

		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity on every frame.
		/// </summary>
		void Update()
		{
			// "back" button of phone equals "Escape". quit app if that's pressed
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				QuitApplication();
			}
		}


		public void AddPlayers(int id, GameObject player)
		{
			_players.Add(id,player);
			ReloadPlayers();
		}

		void ReloadPlayers()
		{
			foreach (var id in _players.Keys)
			{
				int index = id / 1000;
				index -=1;
				index %=2;
				Debug.Log("place" +index );
				_players[id].transform.parent = PlaceHolder.instance.Place[index ].transform;
				// _players[id].transform.position = Vector3.zero; // + _offset;
				if(isAdmin)
					_players[id].transform.position = Vector3.zero + _offset;

				// _players[id].transform.parent.rotation = Quaternion.identity;
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
			Debug.Log( "OnPlayerEnteredRoom() " + other.NickName+ PhotonNetwork.IsMasterClient ); // not seen if you're the player connecting
			
			if ( PhotonNetwork.IsMasterClient )
			{
				Debug.LogFormat( "OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient ); // called before OnPlayerLeftRoom
				isAdmin = PhotonNetwork.IsMasterClient;
				// LoadArena();
			}


		}

		/// <summary>
		/// Called when a Photon Player got disconnected. We need to load a smaller scene.
		/// </summary>
		/// <param name="other">Other.</param>
		public override void OnPlayerLeftRoom( Player other  )
		{
			Debug.Log( "OnPlayerLeftRoom() " + other.NickName+" "+ PhotonNetwork.IsMasterClient ); // seen when other disconnects

			if ( PhotonNetwork.IsMasterClient )
			{
				Debug.LogFormat( "OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient ); // called before OnPlayerLeftRoom
				SceneManager.LoadScene(lobyNameScene);
				// LoadArena(); 
			}
		}

		/// <summary>
		/// Called when the local player left the room. We need to load the launcher scene.
		/// </summary>
		public override void OnLeftRoom()
		{
			// SceneManager.LoadScene("GunStore 1");
		}

		#endregion

		#region Public Methods

		public bool LeaveRoom()
		{
			return PhotonNetwork.LeaveRoom();
		}

		public void QuitApplication()
		{
			Application.Quit();
		}

		#endregion

		#region Private Methods

		void LoadArena()
		{
			if ( ! PhotonNetwork.IsMasterClient )
			{
				Debug.LogError( "PhotonNetwork : Trying to Load a level but we are not the master Client" );
			}

			Debug.LogFormat( "PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount );

			// PhotonNetwork.LoadLevel("PunBasics-Room for "+PhotonNetwork.CurrentRoom.PlayerCount);
			PhotonNetwork.LoadLevel("GamePlay");
		}

		#endregion

	}

}