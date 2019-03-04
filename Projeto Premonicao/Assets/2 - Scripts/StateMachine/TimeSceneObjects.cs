using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSceneObjects : TimeSceneController {
    // Trigger da acao

    [Header("Cena 1")]
    public bool ActionTrigger1;

    [Header("Cena 2")]
    public bool ActionTrigger2;

    [Header("Cena 3")]
    public bool ActionTrigger3;

    public  void ChangeStateObject() {

        switch (Instance.currentState) {
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
