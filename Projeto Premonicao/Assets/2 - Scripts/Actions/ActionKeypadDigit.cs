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

            for (int i = 0; i < Keypad.MaxNumPassword; i++) {
                if (Keypad.DigitsOnscreen[i] != -1) {
                    Keypad.DigitsOnscreen[i] = -1;
                }

                string keypadText = Keypad.KeypadScreen.text;
                keypadText.Remove(i);
                keypadText.Insert(i, "*");

                Keypad.KeypadScreen.text = keypadText;
            }

        } else {

            Debug.Log("noice");
            if (Keypad.DigitsOnscreen.Length < Keypad.MaxNumPassword + 1) {
                Keypad.DigitsOnscreen[Keypad.DigitsOnscreen.Length - 1] = Number;

                string keypadText = Keypad.KeypadScreen.text;

                for (int i = Keypad.MaxNumPassword - 1; i >= 0; i--) {
                    if (i != 0) {

                        keypadText.Remove(i);
                        keypadText.Insert(i, Keypad.KeypadScreen.text[i - 1].ToString());

                    } else {
                        keypadText.Insert(0, Number.ToString());
                    }
                }

                Keypad.KeypadScreen.text = keypadText;
                Debug.Log(Keypad.KeypadScreen.text);
            }

        }

    }

    public override void EndAction() {
        base.EndAction();
    }
}
