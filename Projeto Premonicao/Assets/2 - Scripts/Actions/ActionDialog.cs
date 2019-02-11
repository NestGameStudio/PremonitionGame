using System.Collections;
using UnityEngine;

public delegate void EndOfDialogue();

public class ActionDialog : ActionTrigger
{
    // ------------------------- Variables ------------------------- //

    // --- Public Variables --- //
    [TextArea(1,3)]
    public string PromptHeader;
    public DialoguePrompt[] DialoguePrompts;

    // --- Private Variables --- //
    private EndOfDialogue function;
    private bool startDialogue = false;
    private bool canStartDialogAgain = true;

    // ------------------------- Functions ------------------------- //

    // --- Public Functions --- //

    /// < DoAction(): void >
    /// Show a dialogue that it's selected on Prompt.
    ///  Function changes the value from Cursor so it can move freely in the screen to choose the dialog Prompt.
    ///  Wait if a dialogue it's over so it won't show a new dialogue right after. 
    /// </ DoAction(): void >
    public override void DoAction() {
        base.DoAction();

        MouseController.currentMouseState = MouseState.OnPrompt;

        function = EndAction;

        if (canStartDialogAgain) {
            DialogueManager.Instance.SelectPrompt(DialoguePrompts, function, PromptHeader);
            startDialogue = true;
            canStartDialogAgain = false;
        } else {
            base.EndAction();
        }
    }

    public override void EndAction() {
        base.EndAction();

        MouseController.currentMouseState = MouseState.Default;
        startDialogue = false;
        StartCoroutine(WaitUntilDialogIsFinished());
    }

    // --- Private Functions --- //
    private void Update() {

        if (!DialogueManager.Instance.DialogueSelection && startDialogue) {
            MouseController.currentMouseState = MouseState.OnDialog;
        }
    }

    private IEnumerator WaitUntilDialogIsFinished() {
        
        yield return new WaitForSeconds(0.3f);
        canStartDialogAgain = true;
    }

}
