using System.Collections;
using UnityEngine;

public delegate void EndOfDialogue();

public class ActionDialog : ActionTrigger
{
    public DialoguePrompt[] dialoguePrompts;

    private EndOfDialogue function;
    private bool StartDialogue = false;

    public override void DoAction() {
        base.DoAction();

        function = EndAction;
        if (!StartDialogue) {
            DialogueManager.Instance.SelectPrompt(dialoguePrompts, function);
            StartDialogue = true;
        }else {
            base.EndAction();
        }
    }

    public override void EndAction() {
        base.EndAction();

        StartCoroutine(WaitUntilDialogIsFinished());
    }

    IEnumerator WaitUntilDialogIsFinished() {
        
        yield return new WaitForSeconds(0.3f);
        StartDialogue = false;
    }

}
