using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public void Awake()
    {
        instance = this;
    }

    public void PlayAudio(AudioClip clip)
    {
        if (gameisover.GameIsOver) return;

        GameObject ng = new GameObject("AudioSource");
        AudioSource src = ng.AddComponent<AudioSource>();
        ng.transform.parent = transform;

        src.clip = clip;
        src.Play();
    }

}
