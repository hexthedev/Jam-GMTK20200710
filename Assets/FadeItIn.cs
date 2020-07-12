using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeItIn : MonoBehaviour
{
    public Image img;
    public float alpha = 0;
    public float speed = 1;

    public void Update()
    {
        gameisover.GameIsOver = true;

        if (alpha >= 1) return;
        alpha += Time.deltaTime * speed;
        img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
    }



}
