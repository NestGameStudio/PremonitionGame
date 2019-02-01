using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Relogio : MonoBehaviour
{
    public GameObject clockText;
    public GameObject clockTextSeconds;

    private int seconds = 60;
    private int minutes = 35;
    private float time;
    private int hours = 16;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(countdown());

    }

    // Update is called once per frame
    void Update()
    {
        

        //Debug.Log(minutes);
        //Debug.Log(seconds);

        GameObject.Find("Hours/Minutes").GetComponent<Text>().text = hours + ":" + minutes;
        GameObject.Find("Seconds").GetComponent<Text>().text = seconds.ToString();

        if (seconds == 0)
        {
            minutes -= -1;
            seconds = 59;
        }

    }
    public IEnumerator countdown()
    {
        yield return new WaitForSeconds(1);
        seconds -= 1;
        StartCoroutine(countdown());

    }


}