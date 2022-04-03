using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTarget : MonoBehaviour
{
    Cinemachine.CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    public Transform player;
    private void Awake()
    {
        virtualCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        virtualCamera.m_LookAt = player;
        virtualCamera.m_Follow = player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
