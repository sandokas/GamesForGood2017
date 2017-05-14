using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interaction/Message")]
public class Message : ScriptableObject
{
	[TextArea]
    public string text;
    public enum Type { Message, Response, Information }
    public Type type;
	public float delay;
	public Sprite image;
    public Response[] responses;
    public Character character;
}
