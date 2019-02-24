using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EndOfDialogue();

public class ActionDialog : ActionTrigger
{

    // ------------------------- Variables ------------------------- //

    // --- Public Variables --- //
    [TextArea(1,3)] public string PromptHeader;
    public List<DialoguePrompt> DialoguePrompts = new List<DialoguePrompt>();

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
    ///  AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA - rever isso
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

    /// < EndAction(): void >
    ///  AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA - rever isso
    /// </ EndAction(): void >
    public override void EndAction() {
        base.EndAction();

        MouseController.currentMouseState = MouseState.Default;
        startDialogue = false;
        StartCoroutine(WaitUntilDialogIsFinished());
    }

    // --- Private Functions --- //

    /// < Update(): void >
    ///  AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA - rever isso
    /// </ Update(): void >
    private void Update() {

        if (!DialogueManager.Instance.DialogueSelection && startDialogue) {
            MouseController.currentMouseState = MouseState.OnDialog;
        }
    }

    /// < WaitUntilDialogIsFinished(): IEnumerator >
    ///  AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA - rever isso
    /// </ WaitUntilDialogIsFinished(): IEnumerator >
    private IEnumerator WaitUntilDialogIsFinished() {
        
        yield return new WaitForSeconds(0.3f);
        canStartDialogAgain = true;
    }
}

// ------------------------- Data ------------------------- //

/*public class DialogueComponent : ActionTrigger {

    // --- Public Variables --- //
    [TextArea(1, 3)]
    public string PromptHeader;
    public DialoguePrompt[] DialoguePrompts;
}*/

// ------------------------- Behaviours ------------------------- //

// Tá a ideia aqui é sempre que ativar o item que tem esse componente ele tem que ativar esse sistema
// talvez botar o sistema de diálogo no diálogo e não no NPC?
/*public delegate void EndOfDialogue();

class DialogueSystem: ComponentSystem {

    struct Components {
        public DialogueComponent dialogues;
        public Transform transform;
    }

    // --- Private Variables --- //
    private EndOfDialogue function;
    private bool startDialogue = false;
    private bool canStartDialogAgain = true;


    /// < Update(): void >
    ///  AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA - rever isso
    /// </ Update(): void >
    protected override void OnUpdate() {

        foreach (Components entity in GetEntities<Components>()) {

        }
        //GetEntities<Components>();

        //if (!DialogueManager.Instance.DialogueSelection && startDialogue) {
        //    dialogues.MouseController.currentMouseState = MouseState.OnDialog;
        //}
    }*/

//}
