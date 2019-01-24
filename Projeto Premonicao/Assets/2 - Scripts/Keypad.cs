using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    private static Keypad instance;

    public string CurPassword = "12345";
    public string input;
    public bool OnTrigger;
    public bool DoorOpen;
    public bool KeypadScreen;
    public GameObject door;
    public GameObject cursor;
    public bool KeypadOn = false;

    public static Keypad Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;

    }

    void OnTriggerEnter(Collider other)
    {
        OnTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        OnTrigger = false;
        KeypadScreen = false;
        input = "";
    }

    void Update()
    {
        if (input == CurPassword)
        {
            DoorOpen = true;
            KeypadOn = false;
            cursor.GetComponent<CursorBehaviour>().currentMouseState = MouseState.Default;
        }

        if (DoorOpen)
        {
            //var newRot = Quaternion.RotateTowards(doorHinge.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 250);
            //doorHinge.rotation = newRot;
            door.SetActive(false);
        }
    }

    void OnGUI()
    {
        if (!DoorOpen)
        {
            if (OnTrigger)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Press 'E' to open keypad");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    KeypadScreen = true;
                    KeypadOn = true;
                    cursor.GetComponent<CursorBehaviour>().currentMouseState = MouseState.OnPrompt;
                    OnTrigger = false;
                }
            }

            if (KeypadScreen)
            {
                
                GUI.Box(new Rect(600, 200, 320, 455), "");
                GUI.Box(new Rect(605, 205, 310, 25), input);


                if (GUI.Button(new Rect(605, 235, 100, 100), "1"))
                {
                    input = input + "1";
                }

                if (GUI.Button(new Rect(710, 235, 100, 100), "2"))
                {
                    input = input + "2";
                }

                if (GUI.Button(new Rect(815, 235, 100, 100), "3"))
                {
                    input = input + "3";
                }

                if (GUI.Button(new Rect(605, 340, 100, 100), "4"))
                {
                    input = input + "4";
                }

                if (GUI.Button(new Rect(710, 340, 100, 100), "5"))
                {
                    input = input + "5";
                }

                if (GUI.Button(new Rect(815, 340, 100, 100), "6"))
                {
                    input = input + "6";
                }

                if (GUI.Button(new Rect(605, 445, 100, 100), "7"))
                {
                    input = input + "7";
                }

                if (GUI.Button(new Rect(710, 445, 100, 100), "8"))
                {
                    input = input + "8";
                }

                if (GUI.Button(new Rect(815, 445, 100, 100), "9"))
                {
                    input = input + "9";
                }

                if (GUI.Button(new Rect(710, 550, 100, 100), "0"))
                {
                    input = input + "0";
                }

                if (GUI.Button(new Rect(815, 550, 100, 100), "CLEAR"))
                {
                    input = "";
                }

            }           
        }
    }
}
