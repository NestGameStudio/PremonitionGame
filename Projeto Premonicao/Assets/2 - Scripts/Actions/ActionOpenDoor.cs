using UnityEngine;

public class ActionOpenDoor: ActionInteraction {

    public ActionDialog Monologue;

    public override void DoAction() {
        base.DoAction();

        if (InventoryManager.Instance.checkIfHaveItem(TriggerObject) || isResolved) {
            this.gameObject.SetActive(false);
            if (ConsumeItem && !isResolved)
            {
                InventoryManager.Instance.removeObjectFromInventory(TriggerObject);
            }
        } else {
            if (Monologue != null)
                Monologue.DoAction();
        }

    }

    public override void EndAction() {
        base.EndAction();
    }

    // A questão sobre o que fazer com o item consumido 
    public override void UndoAction() {
        base.UndoAction();

        this.gameObject.SetActive(true);
    }

}

