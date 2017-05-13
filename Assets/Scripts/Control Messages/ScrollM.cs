using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollM : MonoBehaviour {

	public List<RectTransform> 	messages;
	public RectTransform		maxM;
	public RectTransform		minM;

	public float 				previousMouseY = 0.0f;
	public float 				scrollRatio;

	// Use this for initialization
	void Start () {
		
		GameObject[] m = GameObject.FindGameObjectsWithTag("Messages");

		RectTransform m0 = m[0].GetComponent<RectTransform>();

		maxM = m0;
		minM = m0;

		foreach (GameObject go in m)
		{
			RectTransform reGo = go.GetComponent<RectTransform>();

			Debug.Log(reGo.localPosition.y);
			Debug.Log(maxM.localPosition.y);

			if (reGo.localPosition.y > maxM.localPosition.y)
			{
				maxM = reGo;
			}
			else if (reGo.localScale.y < minM.localPosition.y)
			{
				minM = reGo; 
			}

			messages.Add(reGo);

		}


	}

	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			previousMouseY = Camera.main.ScreenToWorldPoint (Input.mousePosition).y;
		}
		else if (Input.GetMouseButton(0))
		{
			float mouseY = Camera.main.ScreenToWorldPoint (Input.mousePosition).y;

			if (previousMouseY < mouseY && maxM.localPosition.y < 0.0f)
			{
				foreach (RectTransform m in messages)
				{
					float ym = m.localPosition.y;

					ym -= scrollRatio * Time.deltaTime;

					m.localPosition = new Vector3(m.localPosition.x, ym, m.localPosition.z);
				}
			}
			else if (previousMouseY > mouseY && minM.localPosition.y <= -600.0f)
			{
				foreach (RectTransform m in messages)
				{
					float ym = m.localPosition.y;

					ym += scrollRatio * Time.deltaTime;

					m.localPosition = new Vector3(m.localPosition.x, ym, m.localPosition.z);
				}
			}

			previousMouseY = Camera.main.ScreenToWorldPoint (Input.mousePosition).y;
		}
	}
}
