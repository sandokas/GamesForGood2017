using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TargetedInteraction/Character")]
public class Character : ScriptableObject {

	public Interaction interaction;

	public void StartInteraction()
	{
		interaction.Show ();
	}
}
