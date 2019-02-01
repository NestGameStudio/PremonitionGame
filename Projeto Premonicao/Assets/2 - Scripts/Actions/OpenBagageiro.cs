using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBagageiro : MonoBehaviour
{
    private bool open;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        open = !open;
        gameObject.GetComponent<Animator>().SetBool("Open", open);
    }
}
