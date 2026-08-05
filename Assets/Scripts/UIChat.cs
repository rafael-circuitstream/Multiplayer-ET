using UnityEngine;
using TMPro;
using System;
using Unity.Collections;

public class UIChat : MonoBehaviour
{
    [SerializeField] private TMP_InputField messageInputfield;
    [SerializeField] private TextMeshProUGUI chatText;

    public Action<FixedString128Bytes> OnMessageSent;
    
    public void DisplayMessageReceived(FixedString128Bytes message)
    {
        chatText.text += message + "\n";
    }

    public void SendMessageWritten()
    {
        OnMessageSent.Invoke(messageInputfield.text);
        messageInputfield.text = "";
        //
    }

}
