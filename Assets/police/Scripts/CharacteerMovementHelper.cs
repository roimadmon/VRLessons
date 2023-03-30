using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class CharacteerMovementHelper : MonoBehaviour
{
    [SerializeField] private PhotonView photonView;
    private XROrigin m_XROrigin;
    private TrackedPoseDriver LeftHand;
    private TrackedPoseDriver RightHand;
    private CharacterController m_CharacterController;

    private CharacterControllerDriver driver;
    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine)
            return;
        m_XROrigin = GetComponent<XROrigin>();
        m_CharacterController = GetComponent<CharacterController>();
        driver = GetComponent<CharacterControllerDriver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            UpdateCharacterController();
        }
        
    }

    /// <summary>
    /// Updates the <see cref="CharacterController.height"/> and <see cref="CharacterController.center"/>
    /// based on the camera's position.
    /// </summary>
    protected virtual void UpdateCharacterController()
    {
        if (m_XROrigin == null || m_CharacterController == null)
            return;

        var height = Mathf.Clamp(m_XROrigin.CameraInOriginSpaceHeight, driver.minHeight, driver.maxHeight);

        Vector3 center = m_XROrigin.CameraInOriginSpacePos;
        center.y = height / 2f + m_CharacterController.skinWidth;

        m_CharacterController.height = height;
        m_CharacterController.center = center;
    }

}
