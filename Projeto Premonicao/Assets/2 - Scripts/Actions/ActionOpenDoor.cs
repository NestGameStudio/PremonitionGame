﻿using UnityEngine;

public class ActionOpenDoor: ActionInteraction {

    public ActionDialog Monologue;

    public override void DoAction() {
        base.DoAction();

        if (InventoryManager.Instance.checkIfHaveItem(TriggerObject)) {
            this.gameObject.SetActive(false);
            if (ConsumeItem)
            {
                InventoryManager.Instance.removeObjectFromInventory(TriggerObject);
            }
        } else {
            Monologue.DoAction();
        }

    }

    public override void EndAction() {
        base.EndAction();
    }

}

