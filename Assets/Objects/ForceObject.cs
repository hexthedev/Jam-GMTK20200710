using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceObject : MonoBehaviour
{
    public Rigidbody2D rb;

    public void Awake()
    {
        ForceManager.ForceReceivers.Add(rb);
    }
}
