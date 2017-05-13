using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EcraTelemovel : MonoBehaviour {
    public Message startMessage;
    private List<GameObject> gameObjectsOnScreen;
    public GameObject messagePrefab;
    public Vector3 startPosition;
    
	// Use this for initialization
	void Start () {
        gameObjectsOnScreen = new List<GameObject>();
        ShowMessage(startMessage);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowMessage(Message message)
    {
        foreach (GameObject goMessage in gameObjectsOnScreen)
        {
            goMessage.transform.Translate(new Vector3(0, 25, 0));
        }
        GameObject newObject = Instantiate(messagePrefab, startPosition,Quaternion.identity) as GameObject;
        TextMessageScript textMessage = newObject.GetComponent<TextMessageScript>();
        textMessage.Init(message, newObject);

        newObject.transform.SetParent(this.transform);

        Text t = newObject.GetComponentInChildren<Text>();

        t.text = message.text;

        gameObjectsOnScreen.Add(newObject);
    }
    public void NoResponsesOnMessage(Message m)
    {
        Debug.Log("Game has ended due to no more responses");
    }
}
