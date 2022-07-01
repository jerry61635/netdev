using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD1 : MonoBehaviour
{
    public Text playerName;
    public Canvas Hud;
    // Start is called before the first frame update
    void Start()
    {
        Hud = gameObject.GetComponent<Canvas>();
        Hud.worldCamera = GameManager.Instance.Cam;
    }

    // Update is called once per frame
    void Update()
    {
        playerName.text = PlayerState.instance.name;
        playerName.transform.LookAt(GameManager.Instance.Cam.transform);
    }
}
