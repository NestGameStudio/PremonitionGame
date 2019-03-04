using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSceneNPC : TimeSceneController
{
    // Posição e Estado da Quest

    [Header("Cena 1")]
    public Vector3 PositionScene1;
    public bool QuestTrigger1;

    [Header("Cena 2")]
    public Vector3 PositionScene2;
    public bool QuestTrigger2;

    [Header("Cena 3")]
    public Vector3 PositionScene3;
    public bool QuestTrigger3;

    public void ChangeStateNPC() {

        switch (Instance.currentState) {
            case 1:
                Debug.Log("1");
                this.transform.localPosition = PositionScene1;
                break;
            case 2:
                Debug.Log("2");
                this.transform.localPosition = PositionScene2;
                break;
            case 3:
                Debug.Log("3");
                this.transform.localPosition = PositionScene3;
                break;
            case 4:
                this.transform.localPosition = PositionScene3;
                break;
            default:
                this.transform.localPosition = PositionScene3;
                break;
        }

    }

}
