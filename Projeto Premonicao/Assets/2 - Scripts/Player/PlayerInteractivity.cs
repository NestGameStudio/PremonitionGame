using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractivity : MonoBehaviour
{
    private ActionTrigger actionFromObject;
    private int layerMask;

    public GameObject cam;



    [SerializeField]
    private float InteractivityDistance = 10f;

    private void Awake()
    {
        layerMask = ~(1 << LayerMask.NameToLayer("Aviao"));
    }

    // Cria um raio em frente ao player e verifica se há colisão com algum objeto interativo
    public bool CheckIfHitObject() {

        Vector3 fwd = cam.transform.TransformDirection(Vector3.forward);
        
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, fwd, out hit, InteractivityDistance, layerMask)) {
        
            // Se o objeto possuir esse script ou seus scripts herdeiros então ele é interativo
            actionFromObject = hit.transform.GetComponent<ActionTrigger>();

            if (actionFromObject != null) {
                return true;
            } else {
                return false;
            }
        }

        return false;
    }

    public void TriggerActionOnGameObject() {

        if (CheckIfHitObject()) {
            actionFromObject.DoAction();
        }

    }
}
