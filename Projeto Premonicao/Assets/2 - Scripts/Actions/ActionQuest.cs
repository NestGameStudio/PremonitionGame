using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionQuest : ActionTrigger {

    public GameObject changedObject;

    [Header("Cena 1")]
    public Vector3 NewPosition1;

    [Header("Cena 2")]
    public Vector3 NewPosition2;

    [Header("Cena 3")]
    public Vector3 NewPosition3;

    public override void DoAction() {
        base.DoAction();

        changedObject.GetComponent<TimeSceneNPC>().PositionScene1 = NewPosition1;
        changedObject.GetComponent<TimeSceneNPC>().PositionScene2 = NewPosition2;
        changedObject.GetComponent<TimeSceneNPC>().PositionScene3 = NewPosition3;

    }

    public override void EndAction() {
        base.EndAction();

    }

    // clica em um objeto, O NPC muda de posicao nas proximas cenas 



}
