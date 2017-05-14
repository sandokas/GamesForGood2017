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

		Vector3 newPos = new Vector3 (-50.0f, -100.0f, 0.0f);
		RectTransform rect;

		i.transform.SetParent (canvas.transform);
		i.transform.localPosition = new Vector3 (newPos.x, newPos.y, i.transform.position.z);
		rect = i.GetComponent<RectTransform>();
		UpdateMessagePosition(rect.sizeDelta.y);

		p.transform.localPosition = new Vector3 (newPos.x - 20.0f , newPos.y, p.transform.position.z);
		rect = p.GetComponent<RectTransform>();
		rect.sizeDelta = new Vector2 (30.0f, 30.0f);
		p.transform.SetParent (canvas.transform);
		UpdateMessagePosition(90.0f);
	}
		
	public void CreateTextF (Message m)
	{
		GameObject t = Instantiate (text_Prefab);
		GameObject p = Instantiate (profilePrefab);

		Vector3 newPos = new Vector3 (-50.0f, -170.0f, 0.0f);
		RectTransform rect;

		t.transform.SetParent (canvas.transform);
		Text textT = t.GetComponentInChildren<Text>();
		textT.text = m.text;
		t.transform.localPosition = new Vector3 (newPos.x, newPos.y, t.transform.position.z);
		rect = t.GetComponent<RectTransform>();

		p.transform.localPosition = new Vector3 (newPos.x - 20.0f , newPos.y, p.transform.position.z);
		rect.sizeDelta = new Vector2 (30.0f, 30.0f);
		p.transform.SetParent (canvas.transform);

		UpdateMessagePosition(90.0f);
	}

	// Change the text of a (child) UI text game object
	private void ChangeTextInChild (GameObject parent, Message msg)
	{
		Text textInChild = parent.GetComponentInChildren<Text>();
		textInChild.text = msg.text;
	}

	public void CreateEventF (Message m)
	{
		// Instantiate our prefabs
		GameObject t = Instantiate (text_Prefab, canvas.transform);
		GameObject e = Instantiate (event_Prefab, canvas.transform);
		GameObject p = Instantiate (profilePrefab, canvas.transform);

		// All previous messages will go up
		Vector3 newPos = new Vector3 (0.0f, -170.0f, 0.0f);
		RectTransform rect;

		ChangeTextInChild (t, m);

		t.transform.localPosition = new Vector3 (newPos.x, newPos.y + 50.0f, t.transform.position.z);
		rect = t.GetComponent<RectTransform>();
		t.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		// Change width
		rect.sizeDelta = new Vector2 (200, rect.sizeDelta.y);

		e.transform.localPosition = new Vector3 (newPos.x, newPos.y, e.transform.position.z);
		e.GetComponent<TextMessageScript>().Init(m);
		e.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

		p.transform.localPosition = new Vector3 (newPos.x - 70.0f, newPos.y, p.transform.position.z);
		p.GetComponent<RectTransform>().sizeDelta = new Vector2 (30.0f, 30.0f);
		p.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

		UpdateMessagePosition(90.0f);
	}

	public void UpdateMessagePosition (float p)
	{
		GameObject[] ms = GameObject.FindGameObjectsWithTag("Messages");
		foreach (GameObject m in ms)
		{
			if (m.name.Contains("Profile"))
			{
					m.transform.Translate (0.0f, p + 20.0f, 0.0f);	
			}
			else
			{
				m.transform.Translate (new Vector3 (0.0f, p, 0.0f));
			}
		}
	}
}
