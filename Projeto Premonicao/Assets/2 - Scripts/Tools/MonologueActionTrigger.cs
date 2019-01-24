using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueActionTrigger : MonoBehaviour
{
    public void PlayAction() {
        this.GetComponent<ActionTrigger>().DoAction();
    }
}
