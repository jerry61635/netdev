using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class PlayerHUD1 : NetworkBehaviour
{
    public Text playerName;
    public Canvas Hud;
    // Start is called before the first frame update
    void Start()
    {
        Hud.worldCamera = GameManager.Instance.Cam;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            playerName.transform.LookAt(GameManager.Instance.Cam.transform);
            playerName.text = PlayerState.name_p;
        }
    }
}
