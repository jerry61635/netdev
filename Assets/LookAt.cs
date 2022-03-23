using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LookAt : MonoBehaviour
{
    Cinemachine.CinemachineVirtualCamera c_VirtualCamera;
    [SerializeField] Transform target;

    private void Awake()
    {
        c_VirtualCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }
    private void Start()
    {
        c_VirtualCamera.m_LookAt = target.transform;
        c_VirtualCamera.m_Follow = target.transform;
    }
}
