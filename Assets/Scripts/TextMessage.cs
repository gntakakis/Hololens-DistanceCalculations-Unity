using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMessage : MonoBehaviour {

    public static TextMessage Instance { get; private set; }

    public GameObject textMessageGmObj;

    void Awake()
    {
        Instance = this;
    }

    public void ChangeTextMessage(string textMessage)
    {
        textMessageGmObj.GetComponent<TextMesh>().text = textMessage; 
    }
}
