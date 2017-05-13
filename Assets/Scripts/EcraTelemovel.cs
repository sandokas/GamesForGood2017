using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EcraTelemovel : MonoBehaviour {

    public Message startMessage;
	// Use this for initialization
	void Start () {
        ShowMessage(startMessage);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowMessage(Message message)
    {
        Text myText = GetComponent<Text>();
        myText.text = message.description;
    }


}
