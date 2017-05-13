using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Telemovel/Response")]
public class Response : ScriptableObject
{
    [TextArea]
    public string description;
    public Message message;
    /*
    void Test()
    {
        message.description;
    }*/
}
