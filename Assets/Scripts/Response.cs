using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interaction/Response")]
public class Response : ScriptableObject
{
    public string textTooltip;
    [TextArea]
    public string text;
	public bool censored;
    public Message message;
}
