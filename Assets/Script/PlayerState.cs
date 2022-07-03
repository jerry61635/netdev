using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState :MonoBehaviour
{
    
    public static string name_p;
    public float health = 100;
    void Awake()
    {
        name_p = ConnectHUD.PlayerName;
    }


}
