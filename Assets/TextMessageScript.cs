﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMessageScript : MonoBehaviour {
	private Message message;
	public List<GameObject> buttons;

    public void Init(Message m)
    {
        message = m;

        buttons = new List<GameObject>();
        //Button[] buttons = o.GetComponentsInChildren<Button>();
        if (message.type == Message.Type.Message)
        {
            int i = 0;

			Debug.Log(message.responses.Length);
			if (message.responses.Length == 0)
			{
				Destroy(gameObject);
			}

            foreach (Response r in message.responses)
            {
                //TODO: Vector buttonPositions cannot be shorter than numbers of responses
				if (r != null)
				{
					GameObject go = gameObject.transform.GetChild(i).gameObject;

	                buttons.Add(go);

	                Button b = go.GetComponent<Button>();
	                b.name = r.textTooltip;
	                Text t = b.GetComponentInChildren<Text>();
	                t.text = r.textTooltip;
	                b.onClick.AddListener(delegate { DoResponse(b.name); });
				}

                i++;
            }
        }
        else
        {
            if (message.responses.Length > 0) { 
                ShowMessage(message.responses[0].message);
            } else
            {
                EcraTelemovel ecraTelemovel = this.GetComponentInParent<EcraTelemovel>();
                ecraTelemovel.NoResponsesOnMessage(message);
            }
        }
        //share.onClick += DoShare();
    }

    public void DoResponse(string textTooltip)
    {
        foreach (GameObject go in buttons)
        {
            //Button b = go.GetComponent<Button>();
			Destroy(go);
        }

        foreach (Response r in message.responses)
        {
            if (r.textTooltip == textTooltip)
            {
                ShowMessage(r.message);
            }
        }
    }
    public void ShowMessage(Message message)
    {
        EcraTelemovel ecraTelemovel = this.GetComponentInParent<EcraTelemovel>();

        ecraTelemovel.ShowMessage(message);
    }
}

