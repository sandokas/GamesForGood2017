using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interaction/Interaction")]
public class Interaction : ScriptableObject {

	public Message[] messages;
	public Response[] responses;

	public void Show()
	{
		foreach (Message message in messages) {
			Debug.Log (message.text);
		}

		foreach (Response response in responses) {
			Debug.Log (response.text);
		}
	}
}
