using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Day/TargetedInteraction")]
public class TargetedInteraction : ScriptableObject {

	public Character character;

	public void StartTargetedInteraction()
	{
		character.StartInteraction ();
	}
}
