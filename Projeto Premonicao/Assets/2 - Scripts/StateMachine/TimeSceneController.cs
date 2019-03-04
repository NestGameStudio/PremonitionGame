﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSceneController : MonoBehaviour
{
    private static TimeSceneController instance;

    [Range(1, 5)]
    [HideInInspector] public int currentState = 1;

    public static TimeSceneController Instance { get { return instance; } }

    public void ChangeSceneState(bool increase) {

        if (increase) {

            if (currentState != 5)
                currentState += 1;
            Debug.Log("Adiantou uma cena " + currentState);
        } else {

            if (currentState != 1)
                currentState -= 1;
            Debug.Log("Voltou uma cena " + currentState);
        }

        foreach(TimeSceneNPC NPCs in GameObject.FindObjectsOfType<TimeSceneNPC>()) {
            NPCs.ChangeStateNPC();
        }

        foreach (TimeSceneObjects objects in GameObject.FindObjectsOfType<TimeSceneObjects>()) {
            objects.ChangeStateObject();
        }

    }

    private void Awake() { instance = this; }

    private void Update() {  }

}
