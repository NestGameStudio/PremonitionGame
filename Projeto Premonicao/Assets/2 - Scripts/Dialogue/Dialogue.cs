﻿using System.Collections;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    public string name;
    [TextArea(1,10)]
    public string[] sentences;
}
