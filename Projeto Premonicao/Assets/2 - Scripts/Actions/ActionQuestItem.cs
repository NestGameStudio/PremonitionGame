using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionQuestItem : ActionInteraction {

    public GameObject rewardObject;

    [Header("Cena 1")]
    public bool ActiveInScene1 = true;
    public Vector3 NewPosition1;

    [Header("Cena 2")]
    public bool ActiveInScene2 = true;
    public Vector3 NewPosition2;

    [Header("Cena 3")]
    public bool ActiveInScene3 = true;
    public Vector3 NewPosition3;

    // parar de fazer ele multiplicar cartões infinitos e selecionar qual cena que se pode fazer essa quest

    public override void DoAction() {
        base.DoAction();

        if (InventoryManager.Instance.checkIfHaveItem(TriggerObject)) {

            if ((TimeSceneController.Instance.currentState == 1 && ActiveInScene1) || (TimeSceneController.Instance.currentState == 2 && ActiveInScene2) || (TimeSceneController.Instance.currentState == 3 && ActiveInScene3)) {
                InventoryManager.Instance.removeObjectFromInventory(TriggerObject);
                rewardObject.SetActive(true);
                this.GetComponent<TimeSceneNPC>().PositionScene1 = NewPosition1;
                this.GetComponent<TimeSceneNPC>().PositionScene2 = NewPosition2;
                this.GetComponent<TimeSceneNPC>().PositionScene3 = NewPosition3;
            } else {
                Debug.Log("Quest não está ativa");
            }

        } else {
            Debug.Log("Não possui chave");
        }
    }

    public override void EndAction() {
        base.EndAction();
    }
}
