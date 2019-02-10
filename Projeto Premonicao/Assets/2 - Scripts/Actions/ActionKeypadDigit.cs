using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionKeypadDigit: ActionTrigger
{
    public bool CleanButton = false;
    public int Number = 0;

    private ActionKeypad Keypad;

    private void Start() {
        GameObject KeypadGO = this.transform.parent.parent.parent.parent.gameObject;
        Keypad = KeypadGO.GetComponent<ActionKeypad>();

    }

    public override void DoAction() {
        base.DoAction();

        if (CleanButton) {
            Keypad.CleanKeypad();
        } else {
            Keypad.AddDigit(Number);
        }

    }

    public override void EndAction() {
        base.EndAction();
    }
}
