using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateB : MonoBehaviour {

	public GameObject buble_Prefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateMe ()
	{
		GameObject b = Instantiate (buble_Prefab);
		GameObject c = GameObject.Find("Canvas");
		Messages mc = c.GetComponent<Messages> ();

		b.transform.SetParent(c.transform);
		mc.lstM.Add (b);
		RectTransform rtB = b.GetComponent<RectTransform>();

		rtB.anchorMin = new Vector2 (0.29f, 0.01f);
		rtB.anchorMax = new Vector2 (0.69f, 0.21f);

		rtB.offsetMax = new Vector2(0.0f, 0.0f);
		rtB.offsetMin = new Vector2(0.0f, 0.0f);

		UpdateMessagesPostions(mc);
	}

	public void UpdateMessagesPostions (Messages ms)
	{
		Vector2 anchorMi = new Vector2 (0.29f, 0.01f);
		Vector2 anchorMa = new Vector2 (0.69f, 0.21f);

		for (int i = ms.lstM.Count - 1; i >= 0; i--)
		{
			GameObject m = ms.lstM[i];
			Debug.Log(m.name);

			RectTransform rtB = m.GetComponent<RectTransform>();

			Debug.Log(anchorMi);
			Debug.Log(anchorMa);

			rtB.anchorMin = anchorMi;
			rtB.anchorMax = anchorMa;

			Debug.Log("MUDEO");
			Debug.Log(rtB.anchorMin);
			Debug.Log(rtB.anchorMax);
			anchorMi = new Vector2 (anchorMi.x, anchorMi.y + 0.3f);
			anchorMa = new Vector2 (anchorMa.x, anchorMa.y + 0.3f);


			rtB.offsetMax = new Vector2(0.0f, 0.0f);
			rtB.offsetMin = new Vector2(0.0f, 0.0f);
		}
	}
}
