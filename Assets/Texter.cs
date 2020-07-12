using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texter : MonoBehaviour
{
    public SpriteRenderer sr;

    public static Texter instance;

    Coroutine rt;


    public Sprite[] texts;
    public Sprite[] faces;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        StartCoroutine(StartRout());
    }

    public void ShowTextSprite(Sprite txt, float seconds)
    {
        if (rt != null) StopCoroutine(rt);
        sr.sprite = txt;
        StartCoroutine(TRout(seconds));
    }

    IEnumerator TRout(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        sr.sprite = null;
    }

    IEnumerator StartRout()
    {
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < texts.Length; i++)
        {
            sr.sprite = texts[i];
            FaceSwapper.instance.ChangeFace(faces[i], 4f);
            yield return new WaitForSeconds(4f);
            sr.sprite = null;
            yield return new WaitForSeconds(1f);
        }
    }
}
