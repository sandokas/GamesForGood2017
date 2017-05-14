using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollM : MonoBehaviour {

	public RectTransform[] 		messages;
	public RectTransform		maxM;
	public RectTransform		minM;

	public float 				previousMouseY = 0.0f;
	public float 				scrollRatio;

	// Use this for initialization
	void Start () {


	}

	void Update ()
	{
		
		if (messages.Length != 0)
		{
			if (Input.GetMouseButtonDown(0))
			{
				previousMouseY = Camera.main.ScreenToWorldPoint (Input.mousePosition).y;
			}
			else if (Input.GetMouseButton(0))
			{
				float mouseY = Camera.main.ScreenToWorldPoint (Input.mousePosition).y;

				if (previousMouseY < mouseY && minM.localPosition.y <= -100.0f)
				{
					foreach (RectTransform m in messages)
					{
						float ym = m.localPosition.y;

						ym += scrollRatio * Time.deltaTime;

						m.localPosition = new Vector3(m.localPosition.x, ym, m.localPosition.z);
					}
				}

				if (previousMouseY > mouseY && maxM.localPosition.y >= 175.0f)
				{
					foreach (RectTransform m in messages)
					{
						float ym = m.localPosition.y;

						ym -= scrollRatio * Time.deltaTime;

						m.localPosition = new Vector3(m.localPosition.x, ym, m.localPosition.z);
					}
				}

				previousMouseY = Camera.main.ScreenToWorldPoint (Input.mousePosition).y;
			}
		}
	}
}

 
