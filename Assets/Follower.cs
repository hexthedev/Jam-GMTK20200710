using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform follow;

    public void Update()
    {
        transform.position = follow.position;
        transform.localScale = Vector3.one * follow.localScale.x;
    }
}
