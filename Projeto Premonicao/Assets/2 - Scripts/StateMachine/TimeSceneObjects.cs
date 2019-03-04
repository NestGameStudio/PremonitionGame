using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSceneObjects : MonoBehaviour {
    // Trigger da acao

    [Header("Cena 1")]
    private bool ActionTrigger1 = false;

    [Header("Cena 2")]
    private bool ActionTrigger2 = false;

    [Header("Cena 3")]
    private bool ActionTrigger3 = false;

    public void ChangeStateObject() {

        switch (TimeSceneController.Instance.currentState) {
            case 1:

                if (ActionTrigger1) {
                    this.GetComponent<ActionTrigger>().isResolved = true;
                } else {
                    this.GetComponent<ActionTrigger>().UndoAction();
                }

                break;
            case 2:

                if (ActionTrigger2) {
                    this.GetComponent<ActionTrigger>().isResolved = true;
                } else {
                    this.GetComponent<ActionTrigger>().UndoAction();
                }

                break;
            case 3:

                if (ActionTrigger3) {
                    this.GetComponent<ActionTrigger>().isResolved = true;
                } else {
                    this.GetComponent<ActionTrigger>().UndoAction();
                }

                break;
            case 4:

                if (ActionTrigger3) {
                    this.GetComponent<ActionTrigger>().isResolved = true;
                } else {
                    this.GetComponent<ActionTrigger>().UndoAction();
                }

                break;
            default:

                if (ActionTrigger3) {
                    this.GetComponent<ActionTrigger>().isResolved = true;
                } else {
                    this.GetComponent<ActionTrigger>().UndoAction();
                }

                break;
        }

    }

    public void ActivateTrigger() {

        switch (TimeSceneController.Instance.currentState) {
            case 1:
                ActionTrigger1 = true;
                ActionTrigger2 = true;
                ActionTrigger3 = true;
                break;
            case 2:
                ActionTrigger2 = true;
                ActionTrigger3 = true;
                break;
            case 3:
                ActionTrigger3 = true;
                break;
            case 4:
                ActionTrigger3 = true;
                break;
            case 5:
                ActionTrigger3 = true;
                break;
        }

    }

}
