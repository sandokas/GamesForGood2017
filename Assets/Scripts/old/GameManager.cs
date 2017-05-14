using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ScriptableObject {

	public Day[] days;

	void Start()
	{
		foreach (Day day in days) {
			day.StartDay ();
		}
	}
}
