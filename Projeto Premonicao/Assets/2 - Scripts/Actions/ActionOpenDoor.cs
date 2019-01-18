using UnityEngine;

public class ActionOpenDoor: ActionInteraction {

    public override void DoAction() {
        base.DoAction();

        if (InventoryManager.Instance.checkIfHaveItem(TriggerObject)) {
            this.gameObject.SetActive(false);
            if (ConsumeItem)
            {
                InventoryManager.Instance.removeObjectFromInventory(TriggerObject);
            }
        } else {
            Debug.Log("Porta Trancada");
        }

    }

    public override void EndAction() {
        base.EndAction();
    }

}

