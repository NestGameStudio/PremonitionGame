using System.Collections;
using UnityEngine;

public delegate void EndOfDialogue();

public class ActionDialog : ActionTrigger
{
    public Dialogue dialogue;

    private EndOfDialogue function;


    public override void DoAction() {
        base.DoAction();

        function = EndAction;

        DialogueManager.Instance.StartDialogue(dialogue, function);
    }

    public override void EndAction() {
        base.EndAction();

        Debug.Log("Terminou Diálogo");
    }

    IEnumerator WaitUntilDialogIsFinished() {

        yield return new WaitForSeconds(5f);
        EndAction();
        
    }

}
