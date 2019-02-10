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

    private bool didAction = false;

    private void Start() {

        DigitsOnscreen = new int[MaxNumPassword];

        // initiate screen
        for (int i = 0; i < MaxNumPassword; i++) {
            DigitsOnscreen[i] = -1;
            KeypadScreen.text += " ";
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

    public void AddDigit(int number) {

        char[] keypadText = KeypadScreen.text.ToCharArray();

        for (int i = 0; i <= MaxNumPassword - 1; i++) {

            if (DigitsOnscreen[i] == -1 && i != MaxNumPassword - 1) {

                // Transform the number into the Unicode system
                keypadText[i] = char.ConvertFromUtf32(number + 48)[0];
                DigitsOnscreen[i] = number;
                break;
            }
        }

        KeypadScreen.text = new string(keypadText);
        VerifyPassword();

    }

    public void CleanKeypad() {

        KeypadScreen.text = " ";

        for (int i = 0; i < MaxNumPassword; i++) {

            DigitsOnscreen[i] = -1;
            KeypadScreen.text += " ";
        }

    }

    private void VerifyPassword() {

        if (!didAction) {

            if (int.Parse(KeypadScreen.text) == Password) {
                
                // tentar fazer iiso ser mais versártil
                TriggerObject.gameObject.SetActive(false);
                didAction = true;
            }
        }

    }
}
