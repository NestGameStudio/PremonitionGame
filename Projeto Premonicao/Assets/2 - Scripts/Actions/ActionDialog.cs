using System.Collections;
using UnityEngine;

public class ActionDialog : ActionTrigger
{
    public override void DoAction() {
        base.DoAction();

        Debug.Log("Estou falando");
        StartCoroutine(WaitUntilDialogIsFinished());

    }

    public override void EndAction() {
        base.EndAction();

        Debug.Log("Terminou Diálogo");
    }

    IEnumerator WaitUntilDialogIsFinished() {

        for (; ; ) {
            yield return new WaitForSeconds(5f);
            EndAction();
        }
    }

}
