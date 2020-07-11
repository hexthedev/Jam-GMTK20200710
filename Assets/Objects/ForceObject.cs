using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceObject : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public void Initalize(float mass)
    {
        transform.localScale = new Vector3(mass, mass, mass);
        rb.mass = mass;
    }

    public void Awake()
    {
        ForceManager.ForceReceivers.Add(this);
    }
}
