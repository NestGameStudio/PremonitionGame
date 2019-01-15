using UnityEngine;

public class ActionGrabObject : ActionTrigger {

    public Object interactiveObject;

    // Abre o painel de descrição e guarda o objeto no inventário
    public override void DoAction() {
        base.DoAction();

        Debug.Log(interactiveObject.Name);
        Debug.Log(interactiveObject.Description);

        InventoryManager.Instance.putIntemInInventory(interactiveObject);
        interactiveObject.Model.transform.parent.parent.gameObject.SetActive(false);
    }

    public override void EndAction() {
        base.EndAction();
    }

}
