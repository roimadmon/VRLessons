using Photon.Pun;
using UnityEngine;

public class RemoveComponents : MonoBehaviour
{
    [SerializeField] private PhotonView photonView;

    [SerializeField] private Component[] components;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        if (!photonView.IsMine)
            foreach (Component component in components)
            {
                Destroy(component);
            }

        else
        {
            photonView.gameObject.name = "me ";
            
        }
    }
}

  