using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceObject : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sren;
    public PossibleSprites pspr;
    public PlanetClips clip;
    public AudioSource src;

    [Header("Options")]
    public float massMin = 1;
    public float massMax = 2;
    public float massMod = 1;
    public FloatHeart fh;

    [Header("Debug")]
    public Vector3 cachedVelocity;
    public float cachedAngularVelocity;
    public bool isPaused;

    public void Initalize(float mass)
    {
        transform.localScale = new Vector3(mass, mass, mass);
        rb.mass = mass * massMod;
        rb.velocity = new Vector2(Random.Range(0, 1f), Random.Range(0, 1f) );
    }

    public float StealMass(float mass)
    {
        if(rb.mass < mass)
        {
            Destroy(gameObject);
            return rb.mass;
        }

        rb.mass -= mass;
        transform.localScale -= Vector3.one * mass / massMod;
        return mass;
    }

    public void Awake()
    {
        ForceManager.ForceReceivers.Add(this);
        sren.sprite = pspr.GetRandom();

        Initalize(Random.Range(massMin, massMax));
    }

    //public void OnValidate()
    //{
    //    rb.mass = size;
    //    transform.localScale = Vector3.one * size;
    //}

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
