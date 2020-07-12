using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorControl : MonoBehaviour
{
    public static CursorControl instance;

    public RectTransform trans;
    public Image img;

    public float minX;
    public float maxX;

    public float targetX;
    public float speedFactor;

    public Color Netural;
    public Color Love;
    public Color Sad;

    public float minSad;
    public float maxLove;

    public float curLove;
    public float loveSpan;

    public float cur;
    public float dist;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        loveSpan = (maxLove - minSad);
        curLove = minSad + loveSpan / 2;
    }

    public void SetLove(float love)
    {
        curLove = Mathf.Clamp(curLove + love, minSad, maxLove);

        float loveFactor = (love - minSad) / loveSpan;
        float xSpan = maxX - minX;
        targetX = minX + xSpan * loveFactor;
    }

    public void FixedUpdate()
    {
        cur = trans.anchoredPosition.x;
        dist = targetX - cur;

        Color c;

        if(Mathf.Abs(dist) > 0.25f)
        {
            c = Mathf.Sign(dist) < 0 ? Sad : Love;
            trans.anchoredPosition += new Vector2(dist * Time.fixedDeltaTime, 0);
        } else
        {
            c = Netural;
        }

        img.color = c;
    }
}
