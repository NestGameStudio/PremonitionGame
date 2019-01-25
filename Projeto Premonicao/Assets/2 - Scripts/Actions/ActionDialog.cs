using System.Collections;
using UnityEngine;

public delegate void EndOfDialogue();

public class ActionDialog : ActionTrigger
{
    [TextArea(1,3)]
    public string PrompHeader;

    public DialoguePrompt[] dialoguePrompts;

    private EndOfDialogue function;
    private bool StartDialogue = false;
    private bool CanStartDialogAgain = true;

    private void Update() {
        
        if (!DialogueManager.Instance.DialogueSelection && StartDialogue) {
            MouseController.currentMouseState = MouseState.OnDialog;
        }
    }

    public override void DoAction() {
        base.DoAction();

        MouseController.currentMouseState = MouseState.OnPrompt;

        function = EndAction;
        if (CanStartDialogAgain) {
            DialogueManager.Instance.SelectPrompt(dialoguePrompts, function, PrompHeader);
            StartDialogue = true;
            CanStartDialogAgain = false;
        } else {
            base.EndAction();
        }
    }

    public override void EndAction() {
        base.EndAction();

        MouseController.currentMouseState = MouseState.Default;
        StartDialogue = false;
        StartCoroutine(WaitUntilDialogIsFinished());
    }

    IEnumerator WaitUntilDialogIsFinished() {
        
        yield return new WaitForSeconds(0.3f);
        CanStartDialogAgain = true;
    }

}
