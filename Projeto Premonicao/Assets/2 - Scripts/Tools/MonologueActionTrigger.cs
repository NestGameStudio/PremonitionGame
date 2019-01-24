using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueActionTrigger : MonoBehaviour
{
    public void PlayAction() {
        if (this.GetComponent<ActionTrigger>() != null)
            this.GetComponent<ActionTrigger>().DoAction();
        else
            Debug.Log("Não tem action saporra");
    }
}
