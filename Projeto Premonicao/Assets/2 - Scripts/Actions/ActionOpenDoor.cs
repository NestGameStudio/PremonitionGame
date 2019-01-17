using UnityEngine;

public class ActionOpenDoor: ActionInteraction {

    public override void DoAction() {
        base.DoAction();

        if (InventoryManager.Instance.checkIfHaveItem(TriggerObject)) {
            this.gameObject.SetActive(false);
            InventoryManager.Instance.removeObjectFromInventory(TriggerObject);
        } else {
            Debug.Log("Não Abriu");
        }

    }

    public override void EndAction() {
        base.EndAction();
    }

}

