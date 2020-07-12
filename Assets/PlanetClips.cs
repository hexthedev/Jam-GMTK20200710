using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlanetVoices")]
public class PlanetClips : ScriptableObject
{
    public AudioClip[] Clips;

    public AudioClip GetRandom()
    {
        return Clips[Random.Range(0, Clips.Length)];
    }
}
