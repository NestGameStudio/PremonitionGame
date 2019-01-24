using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ActionVictory : ActionInteraction {

    public Text VictoryText;
    public RespawnControl Respawn;

    public override void DoAction()
    {
        base.DoAction();

        if (InventoryManager.Instance.checkIfHaveItem(TriggerObject))
        { 
            if (ConsumeItem)
            {
                InventoryManager.Instance.removeObjectFromInventory(TriggerObject);
            }
            VictoryText.gameObject.SetActive(true);
            Respawn.time += 20;
            StartCoroutine(EndGame());
        }
        else
        {
            Debug.Log("Porta Trancada");
        }
    }

    public override void EndAction()
    {
        base.EndAction();
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(10f);
        Application.LoadLevel("Menu");
    }

}
