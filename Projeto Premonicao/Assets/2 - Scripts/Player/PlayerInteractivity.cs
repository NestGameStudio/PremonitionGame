using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractivity : MonoBehaviour
{
    [SerializeField]
    private float InteractivityDistance = 10f;

    // Cria um raio em frente ao player e verifica se há colisão com algum objeto interativo
    public void CheckIfHitObject() {

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, InteractivityDistance)) {

            // Se o objeto possuir esse script ou seus scripts herdeiros então ele é interativo
            ActionTrigger actionFromObject = hit.transform.GetComponent<ActionTrigger>();

            if (actionFromObject != null) {
                actionFromObject.DoAction();
            }
        }
    }
}
