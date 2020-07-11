using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceObject : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Options")]
    public float size = 1;
    public FloatHeart fh;

    [Header("Debug")]
    public Vector3 cachedVelocity;
    public float cachedAngularVelocity;
    public bool isPaused;

    public void Initalize(float mass)
    {
        transform.localScale = new Vector3(mass, mass, mass);
        rb.mass = mass;
    }

    public void StealMass(float mass)
    {
        if(rb.mass < mass)
        {
            Destroy(gameObject);
            return;
        }

        rb.mass -= mass;
        transform.localScale -= Vector3.one * mass;
    }

    public void Awake()
    {
        ForceManager.ForceReceivers.Add(this);
    }

    public void OnValidate()
    {
        rb.mass = size;
        transform.localScale = Vector3.one * size;
    }

    public void Pause()
    {
        if (isPaused) return;

        cachedVelocity = rb.velocity;
        cachedAngularVelocity = rb.angularVelocity;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;

        isPaused = true;
    }

    public void UnPause()
    {
        if (!isPaused) return;

        rb.velocity = cachedVelocity;
        rb.angularVelocity = cachedAngularVelocity;

        isPaused = false;
    }
}
