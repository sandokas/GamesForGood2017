using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EcraTelemovel : MonoBehaviour {
    public Message startMessage;
    private List<GameObject> gameObjectsOnScreen;
    public GameObject messagePrefab;
    public Vector3 startPosition;

	public CreateMessage 	createM;
    
	// Use this for initialization
	void Start () {
        gameObjectsOnScreen = new List<GameObject>();
		createM = gameObject.GetComponent<CreateMessage> ();

		if (startMessage != null) {
			StartCoroutine (ShowMessage (startMessage));
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator ShowMessage(Message message)
   	{
		//createM.CreateM(message);
        
		foreach (GameObject goMessage in gameObjectsOnScreen)
        {
            goMessage.transform.Translate(new Vector3(0, 70, 0));
        }

        GameObject newObject = Instantiate(messagePrefab, startPosition,Quaternion.identity) as GameObject;
        TextMessageScript textMessage = newObject.GetComponent<TextMessageScript>();
        textMessage.Init(message);

        newObject.transform.SetParent(this.transform);

        Text t = newObject.GetComponentInChildren<Text>();

		if (message != null) {
			t.text = message.text;
		}

        gameObjectsOnScreen.Add(newObject);

		yield return new WaitForSeconds(3f);
    }

    public IEnumerator NoResponsesOnMessage(Message m)
    {
        Debug.Log("Game has ended due to no more responses");
        yield return new WaitForSeconds(5f);
    }
}
