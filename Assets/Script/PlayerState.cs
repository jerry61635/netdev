using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState :MonoBehaviour
{
    #region Singleton
    public static PlayerState instance;
    void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public string name;
    public float health = 100;
    
    void Start()
    {
        name = ConnectHUD.PlayerName;
    }
}
