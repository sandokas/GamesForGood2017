using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EcraTelemovel : MonoBehaviour {
    public Message startMessage;
    private List<GameObject> gameObjectsOnScreen;
    public GameObject messagePrefab;
    public Vector3 startPosition;
    
	// Use this for initialization
	void Start () {
        gameObjectsOnScreen = new List<GameObject>();

		if (startMessage != null) {
			StartCoroutine (ShowMessage (startMessage));
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator ShowMessage(Message message)
   	{


        string nome = "";

        if (message.character != null)
        {
            nome = message.character.text;
        }


        GameObject newObject = Instantiate(messagePrefab);

        GameObject textG = newObject.transform.Find("NomePersonagem").gameObject;

        Text tG = textG.GetComponent<Text>();
        tG.text = nome;

        RectTransform rectNew = newObject.GetComponent<RectTransform>();
		rectNew.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        rectNew.anchorMin = new Vector2(0.2f, 0.20f);
        rectNew.anchorMax = new Vector2(0.8f, 0.40f);

        rectNew.offsetMin = new Vector2(0.0f, 0.0f);
        rectNew.offsetMax = new Vector2(0.0f, 0.0f);

        TextMessageScript textMessage = newObject.GetComponent<TextMessageScript>();
        textMessage.Init(message);

        newObject.transform.SetParent(this.transform);

        Text t = newObject.GetComponentInChildren<Text>();


        if (message != null) {
			t.text = message.text;
		}

        gameObjectsOnScreen.Add(newObject);

        //Alinha as mensagens
        Vector2 anchorMi = new Vector2(0.20f, 0.20f);
        Vector2 anchorMa = new Vector2(0.8f, 0.40f);

        for (int i = gameObjectsOnScreen.Count - 1; i >= 0; i--)
        {
            GameObject g = gameObjectsOnScreen[i];
            RectTransform rtB = g.GetComponent<RectTransform>();

			rtB.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            rtB.anchorMin = anchorMi;
            rtB.anchorMax = anchorMa;

            anchorMi = new Vector2(anchorMi.x, anchorMi.y + 0.35f);
            anchorMa = new Vector2(anchorMa.x, anchorMa.y + 0.35f);

            rtB.offsetMin = new Vector2 (0.0f, 0.0f);
            rtB.offsetMax = new Vector2(0.0f, 0.0f);
        }

        yield return new WaitForSeconds(3f);
    }

    public IEnumerator NoResponsesOnMessage(Message m)
    {
        Debug.Log("Game has ended due to no more responses");
        yield return new WaitForSeconds(3f);
		SceneManager.LoadScene(1);
    }
}
