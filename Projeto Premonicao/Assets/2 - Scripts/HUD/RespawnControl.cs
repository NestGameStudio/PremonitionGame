﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnControl : MonoBehaviour
{
    private Vector3 respawnPosition;
    private Quaternion respawnRotation;
    [HideInInspector]
    public float time;

    public Text TimeRegression;
    public float ExplosionTimer = 60f;

    public AudioClip ExplosionSound;
    private AudioSource audio;
    public GameObject BlackScreen;

    public ParticleSystem Fumaca;
    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        respawnRotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;

        StartCoroutine(ExplosionTimeRegression());

        audio = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator ExplosionTimeRegression() {

        while (true) {

            if (time <= ExplosionTimer) {

                yield return new WaitForSecondsRealtime(1);
                time += 1;
                if (ExplosionTimer - time >= 0)
                    TimeRegression.text = (ExplosionTimer - time).ToString();
                    
                if(ExplosionTimer - time < ExplosionTimer - ExplosionTimer / 4)
                {
                    Fumaca.Play();
                }

            } else {

                audio.Play();               
                BlackScreen.SetActive(true);
                yield return new WaitForSeconds(7);

                Application.LoadLevel(Application.loadedLevel);
                
                break;
            }

        }

    }

}
