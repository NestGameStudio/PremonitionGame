using UnityEngine;

public class ActionTrigger : MonoBehaviour
{
    public CursorBehaviour MouseController;

    public virtual void DoAction() {  }

    public virtual void EndAction() { MouseController.currentMouseState = MouseState.Default; }
}
