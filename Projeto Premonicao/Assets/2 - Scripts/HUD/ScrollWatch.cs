using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollWatch : MonoBehaviour
{
    private float actualPosition = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<ScrollRect>().horizontalNormalizedPosition = actualPosition;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && actualPosition != 1) // forward
        {
            TimeSceneController.Instance.ChangeSceneState(true);
            actualPosition += 0.5f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && actualPosition != 0) // backwards
        {
            TimeSceneController.Instance.ChangeSceneState(false);
            actualPosition -= 0.5f;
        }
    }
}
