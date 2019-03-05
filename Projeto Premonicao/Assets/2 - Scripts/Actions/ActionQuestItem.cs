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
            InventoryManager.Instance.removeObjectFromInventory(TriggerObject);
            rewardObject.SetActive(true);
        }
    }

    public override void EndAction() {
        base.EndAction();
    }
}
