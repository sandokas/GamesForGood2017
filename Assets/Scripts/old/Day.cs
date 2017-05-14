using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Day : ScriptableObject {

	public TargetedInteraction[] interactions;

	public void StartDay()
	{
		foreach (TargetedInteraction interaction in interactions) {
			interaction.StartTargetedInteraction ();
		}
	}
}
