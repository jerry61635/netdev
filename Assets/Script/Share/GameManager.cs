using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public event System.Action<Player_Movement> OnLocalPlayerJoin;
    //private GameObject gameObject;

    public Camera Cam;
    public Cinemachine.CinemachineFreeLook FreeLook;
    public GameObject chatPanel, textObject;
    public InputField chatBox;
    public CanvasGroup chatCanvasGroup;

    private static GameManager m_Instance;
    public static GameManager Instance;

    void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    private InputManager m_inputManager;
    public InputManager inputManager
    {
        get
        {
            if(m_inputManager == null)
            {
                m_inputManager = gameObject.GetComponent<InputManager>();
            }
            return m_inputManager;
        }
    }
/*
    private Player_Movement m_localPlayer;
    public Player_Movement localPlayer{
        get
        {
            return m_localPlayer;
        }
        set
        {
            m_localPlayer = value;
            if(OnLocalPlayerJoin != null){
                OnLocalPlayerJoin();
            }
        }
    }*/
}
