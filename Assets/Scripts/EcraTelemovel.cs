using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EcraTelemovel : MonoBehaviour {

    public Message startMessage;
    private List<GameObject> gameObjectsOnScreen;
    public Vector3 startMessagePosition;
    
	// Use this for initialization
	void Start () {
        gameObjectsOnScreen = new List<GameObject>();
        ShowMessage(startMessage);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowMessage(Message message)
    {
        foreach (GameObject goMessage in gameObjectsOnScreen)
        {
            goMessage.transform.Translate(new Vector3(5, 0, 0));
        }
        GameObject newMessage = new GameObject(Random.Range(1, 99999999).ToString());
        newMessage.transform.SetParent(this.transform);
        Text newText = newMessage.AddComponent<Text>();
        newText.text = message.description;

        //Text myText = GetComponent<Text>();
        //myText.text = message.description;

    }


}
