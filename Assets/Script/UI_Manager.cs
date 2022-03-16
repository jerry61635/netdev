using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Button startServerButton;

    [SerializeField]
    private Button startHostButton;

    [SerializeField]
    private Button startClientButton;

    [SerializeField]
    private TextMeshProUGUI playersInGameText;

    private void Awake()
    {
        Cursor.visible = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        startHostButton.onClick.AddListener(() => 
        {
            if (NetworkManager.Singleton.StartHost())
            {
                Debug.Log("Host started...");
            }
            else
            {
                Debug.Log("Host could not be started...");
            }
        });

        startServerButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartServer())
            {
                Debug.Log("Server started...");
            }
            else
            {
                Debug.Log("Server could not be started started...");
            }
        });

        startClientButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartClient())
            {
                Debug.Log("Client started...");
            }
            else
            {
                Debug.Log("Client could not be started...");
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        playersInGameText.text = $"Players in game:";
    }
}
