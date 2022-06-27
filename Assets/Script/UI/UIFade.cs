using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public GameObject chatPanel, textObject;
    public InputField chatBox;
    public int maxMessages = 25;
    public float UIHideTime = 0;
    [SerializeField]
    List<Message> messageList = new List<Message>();

    [SerializeField] CanvasGroup UIGroup;
    private bool UIShow = false;

    void Awake()
    {
        HideUI();
    }

    private void Update() {
        if(chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(chatBox.text);
                chatBox.text = "";
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatBox.ActivateInputField();
                UIHideTime = 3;
            }
        }

        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                SendMessageToChat("Q pressed");
        }

        if (UIHideTime <= 1)
        {
            UIGroup.alpha -= Time.deltaTime;
        }
        else if(UIHideTime > 1)
        {
            ShowUI();
            UIHideTime -= Time.deltaTime;
        }
    }
    public void ShowUI()
    {
        UIGroup.alpha = 1;
    }

    public void HideUI()
    {
        UIGroup.alpha = 0;
    }

    public void SendMessageToChat(string text)
    {
        //ShowUI();
        UIHideTime = 3;
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }
        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);
        Debug.Log(chatPanel.transform);
        newMessage.textObject = newText.GetComponent<Text>();
        newMessage.textObject.text = newMessage.text;

        messageList.Add(newMessage);
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
}
