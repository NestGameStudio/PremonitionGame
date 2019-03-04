using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionQuestItem : ActionInteraction {

    public GameObject rewardObject;

    // parar de fazer ele multiplicar cartôes infinitos e selecionar qual cena que se pode fazer essa quest

    public override void DoAction() {
        base.DoAction();

        if (InventoryManager.Instance.checkIfHaveItem(TriggerObject)) {
            InventoryManager.Instance.removeObjectFromInventory(TriggerObject);
            rewardObject.SetActive(true);
            GameObject.Instantiate(rewardObject, this.rewardObject.transform.position, rewardObject.transform.rotation, GameObject.Find("Interactive Objects").transform);
        }
    }

    public override void EndAction() {
        base.EndAction();
    }
}
