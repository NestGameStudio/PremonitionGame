using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : ActionTrigger
{
    public bool isOpen = false;
    public override void DoAction()
    {
        base.DoAction();
        gameObject.GetComponent<Animator>().SetBool("Open", isOpen);
        isOpen = !isOpen;
    }
}
