using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    Texture2D blk;
    public float alph;
    public bool blackOut;
    void Start()
    {
        //make a tiny black texture
        blk = new Texture2D(1, 1);
        blk.SetPixel(0, 0, new Color(0, 0, 0, 0));
        blk.Apply();
    }
    // put it on your screen
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blk);
    }

    void Update()
    {
        if (alph > 0)
        {
            alph -= Time.deltaTime * 0.1f;
            if (alph < 0) { alph = 0f; }
            blk.SetPixel(0, 0, new Color(0, 0, 0, alph));
            blk.Apply();
        }
      
    }

}
