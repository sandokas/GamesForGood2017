using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Telemovel/Message")]
public class Message : ScriptableObject
{
    [TextArea]
    public string description;
    //public Friend message2;
    public Response[] responses;

}
