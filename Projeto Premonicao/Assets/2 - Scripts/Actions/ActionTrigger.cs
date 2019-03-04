using UnityEngine;
using System.Collections.Generic;

/*using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif*/

public class ActionTrigger : MonoBehaviour
{
    public CursorBehaviour MouseController;
    public bool isResolved = false;

    public void Update() {
        
        if (isResolved) {
            DoAction();
        }
    }

    public virtual void DoAction() {

        /*if (this.GetComponent<DialogueAddNew>() != null) {

            // Get the dialogues from each NPC
            foreach (DialogueAddNew NPCs in this.GetComponents<DialogueAddNew>()) {

                if (NPCs.NPC.GetComponent<ActionDialog>() != null) {

                    List<DialoguePrompt> NPCDialogues = NPCs.NPC.GetComponent<ActionDialog>().DialoguePrompts;

                    foreach (DialoguePrompt dialogues in NPCs.DialoguePrompts) {
                        NPCDialogues.Add(dialogues);
                    }

                } else {
                    Debug.Log("Object does not have ActionDialog as component");
                }

            }
        }*/
    }

    public virtual void EndAction() { MouseController.currentMouseState = MouseState.Default; }

    public virtual void UndoAction() { }
}