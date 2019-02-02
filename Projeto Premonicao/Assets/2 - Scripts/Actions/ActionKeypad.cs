using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionKeypad : ActionInteraction
{
    public int Password = 12345;
    public Text KeypadScreen;
    public int MaxNumPassword = 6;

    [HideInInspector]
    public int[] DigitsOnscreen;

    private void Start() {

        DigitsOnscreen = new int[MaxNumPassword];

        // initiate screen
        for (int i = 0; i < MaxNumPassword; i++) {
            DigitsOnscreen[i] = -1;
            KeypadScreen.text += "*";
        }
    }

    public override void DoAction()
    {
        base.DoAction();

    }


    public override void EndAction()
    {
        base.EndAction();
    }
}
