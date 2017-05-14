using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIListener : MonoBehaviour {

	public GameObject contactName;

	public void OnFriendPanelClick()
	{
		Text name = contactName.GetComponent<Text> ();
		Debug.Log ("I pressed on friend named: " + name.text);
	}
}
