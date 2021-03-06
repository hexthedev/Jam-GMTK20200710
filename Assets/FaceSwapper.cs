﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceSwapper : MonoBehaviour
{
    public static FaceSwapper instance;

    public SpriteRenderer rend;
    public CharacterFaces faces;

    Coroutine faceRoutine = null;

    public Sprite sp;

    public void Awake()
    {
        instance = this;
        sp = faces.normal;
    }

    public void ChangeBaseFace(Sprite sp)
    {
        this.sp = sp;
    }

    public void ChangeFace(Sprite face, float time)
    {
        if (faceRoutine != null) StopCoroutine(faceRoutine);
        faceRoutine = StartCoroutine(ChangeFaceRoutine(face, time));
    }

    IEnumerator ChangeFaceRoutine(Sprite face, float time)
    {
        rend.sprite = face;
        yield return new WaitForSeconds(time);
        rend.sprite = sp;
    }
}
