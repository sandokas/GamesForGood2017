using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMessage : MonoBehaviour {

	public GameObject		canvas;

	public GameObject		image_Prefab;
	public GameObject		text_Prefab;
	public GameObject		event_Prefab;
	public GameObject		profilePrefab;

	// Use this for initialization
	void Start () {
		canvas = GameObject.Find("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateM (Message m)
	{
		if (m.type == Message.Type.Message)
		{
			if (!string.IsNullOrEmpty(m.text))
			{
				CreateEventF(m);
			}
		}
		else if (m.type == Message.Type.Response)
		{
			if (string.IsNullOrEmpty(m.text))
			{
				CreateTextF(m);
			} 
		}
	}

	public void CreateImageF ()
	{
		GameObject i =  Instantiate (image_Prefab);
		GameObject p = Instantiate (profilePrefab);

		Vector3 novaP = new Vector3 (-50.0f, -100.0f, 0.0f);
		RectTransform rect;

		i.transform.SetParent (canvas.transform);
		i.transform.localPosition = new Vector3 (novaP.x, novaP.y, i.transform.position.z);
		rect = i.GetComponent<RectTransform>();
		UpdateMessagePosition(rect.sizeDelta.y);

		p.transform.localPosition = new Vector3 (novaP.x - 20.0f , novaP.y, p.transform.position.z);
		rect = p.GetComponent<RectTransform>();
		rect.sizeDelta = new Vector2 (30.0f, 30.0f);
		p.transform.SetParent (canvas.transform);
		UpdateMessagePosition(rect.sizeDelta.y * 3);
	}
		
	public void CreateTextF (Message m)
	{
		GameObject t = Instantiate (text_Prefab);
		GameObject p = Instantiate (profilePrefab);

		Vector3 novaP = new Vector3 (-50.0f, -170.0f, 0.0f);
		RectTransform rect;

		t.transform.SetParent (canvas.transform);
		Text textT = t.GetComponentInChildren<Text>();
		textT.text = m.text;
		t.transform.localPosition = new Vector3 (novaP.x, novaP.y, t.transform.position.z);
		rect = t.GetComponent<RectTransform>();
		UpdateMessagePosition(rect.sizeDelta.y);

		p.transform.localPosition = new Vector3 (novaP.x - 20.0f , novaP.y, p.transform.position.z);
		rect = p.GetComponent<RectTransform>();
		rect.sizeDelta = new Vector2 (30.0f, 30.0f);
		p.transform.SetParent (canvas.transform);
		UpdateMessagePosition(rect.sizeDelta.y * 3);
	}

	public void CreateEventF (Message m)
	{
		GameObject t = Instantiate (text_Prefab);
		GameObject e = Instantiate (event_Prefab);
		GameObject p = Instantiate (profilePrefab);

		Vector3 novaP = new Vector3 (0.0f, -170.0f, 0.0f);
		RectTransform rect;

		t.transform.SetParent (canvas.transform);
		Text textT = t.GetComponentInChildren<Text>();
		textT.text = m.text;
		t.transform.localPosition = new Vector3 (novaP.x, novaP.y, t.transform.position.z);
		rect = t.GetComponent<RectTransform>();
		UpdateMessagePosition(rect.sizeDelta.y);
		t.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
	
		e.transform.localPosition = new Vector3 (novaP.x, novaP.y, e.transform.position.z);
		rect = e.GetComponent<RectTransform>();
		e.transform.SetParent (canvas.transform);
		UpdateMessagePosition(rect.sizeDelta.y);
		e.GetComponent<TextMessageScript>().Init(m);
		e.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

		p.transform.localPosition = new Vector3 (novaP.x, novaP.y, p.transform.position.z);
		rect = p.GetComponent<RectTransform>();
		rect.sizeDelta = new Vector2 (30.0f, 30.0f);
		p.transform.SetParent (canvas.transform);
		p.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		UpdateMessagePosition(rect.sizeDelta.y * 3);
	}

	public void UpdateMessagePosition (float p)
	{
		GameObject[] ms = GameObject.FindGameObjectsWithTag("Messages");
		foreach (GameObject m in ms)
		{
			m.transform.localPosition = new Vector3 (m.transform.localPosition.x , m.transform.localPosition.y + p, 0.0f);
		}
	}
}
