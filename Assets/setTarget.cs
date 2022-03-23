using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setTarget : MonoBehaviour
{
    Cinemachine.CinemachineFreeLook c_VirtualCamera;
    public Transform player;

    private void Awake()
    {
        c_VirtualCamera = GetComponent<Cinemachine.CinemachineFreeLook>();
    }
    private void Start()
    {
        c_VirtualCamera.m_LookAt = player.transform;
        c_VirtualCamera.m_Follow = player;
    }
}
