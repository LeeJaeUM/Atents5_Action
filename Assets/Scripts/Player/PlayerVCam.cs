using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerVCam : MonoBehaviour
{
    private void Start()
    {
        CinemachineVirtualCamera vCam = GetComponent<CinemachineVirtualCamera>();
        vCam.Follow = GameManager.Instance.Player.gameObject.transform;
    }
}
