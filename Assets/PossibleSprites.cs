using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "posSprites")]
public class PossibleSprites : ScriptableObject
{
    public Sprite[] sprites;

    public Sprite GetRandom()
    {
        int index = Random.Range(0, sprites.Length);
        return sprites[index];
    }
}
