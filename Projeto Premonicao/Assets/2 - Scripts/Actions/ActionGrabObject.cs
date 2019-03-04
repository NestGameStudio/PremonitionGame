using UnityEngine;

public class ActionGrabObject : ActionTrigger {

    public Object interactiveObject;

    // Abre o painel de descrição e guarda o objeto no inventário
    public override void DoAction() {
        base.DoAction();

        InventoryManager.Instance.putIntemInInventory(interactiveObject);
    }

    public override void EndAction() {
        base.EndAction();
    }

    public override void UndoAction() {
        base.UndoAction();
    }

}
