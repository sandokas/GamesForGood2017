using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Interaction/Character")]
public class Character : ScriptableObject {
    public Sprite image;
    public string text;
    public bool banned;

}
