using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSceneController : MonoBehaviour
{
    private static TimeSceneController instance;

    [Range(1, 5)]
    private int currentState = 1;

    public static TimeSceneController Instance { get { return instance; } }

    public void Awake() {

        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }

    }

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

    }

    private void Update() {
        
        switch (currentState) {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        }

    }

}
