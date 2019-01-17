using System.Collections;
using UnityEngine;

[System.Serializable]
public class Object {

    public string Name;
    [TextArea(1, 10)]
    public string Description;
    public GameObject Model;
    public Sprite HUDSprite;
}
