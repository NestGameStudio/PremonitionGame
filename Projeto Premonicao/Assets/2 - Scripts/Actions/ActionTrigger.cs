using UnityEngine;

public class ActionTrigger : MonoBehaviour
{
    [SerializeField]
    private CursorBehaviour MouseController;

    public virtual void DoAction() { MouseController.currentMouseState = MouseState.OnAction; }

    public virtual void EndAction() { MouseController.currentMouseState = MouseState.Default; }
}
