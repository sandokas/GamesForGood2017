using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interaction/Response")]
public class Response : ScriptableObject
{
    public string textTooltip;
    public Message message;
    public bool censored;
}
