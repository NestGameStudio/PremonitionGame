using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionQuestItem : ActionInteraction {

    public GameObject rewardObject;

    public bool ActiveInScene1 = true;
    public bool ActiveInScene2 = true;
    public bool ActiveInScene3 = true;

    // parar de fazer ele multiplicar cartôes infinitos e selecionar qual cena que se pode fazer essa quest

    public override void DoAction() {
        base.DoAction();

        if (InventoryManager.Instance.checkIfHaveItem(TriggerObject)) {

            if ((TimeSceneController.Instance.currentState == 1 && ActiveInScene1) || (TimeSceneController.Instance.currentState == 2 && ActiveInScene2) || (TimeSceneController.Instance.currentState == 3 && ActiveInScene3)) {
                InventoryManager.Instance.removeObjectFromInventory(TriggerObject);
                rewardObject.SetActive(true);
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
