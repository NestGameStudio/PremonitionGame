using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSceneNPC : MonoBehaviour
{
    // Posição e Estado da Quest

    [Header("Cena 1")]
    public Vector3 PositionScene1;
    public bool QuestTrigger1 = false;

    [Header("Cena 2")]
    public Vector3 PositionScene2;
    public bool QuestTrigger2 = false;

    [Header("Cena 3")]
    public Vector3 PositionScene3;
    public bool QuestTrigger3 = false;

    public void ChangeStateNPC() {

        switch (TimeSceneController.Instance.currentState) {
            case 1:
                this.transform.localPosition = PositionScene1;
                break;
            case 2:
                this.transform.localPosition = PositionScene2;
                break;
            case 3:
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
