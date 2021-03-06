﻿using UnityEngine;

public class FixedPuller : AForceProvider
{
    public float forceFac = 1;
    public float distanceFac = 1;   

    public Vector2 pull;
    public float pull_mag;
    public Vector2 direction;

    public Rigidbody2D rb;
    public float massCutoff; // how much more mass can something have before pulling is ignored

    public void Awake()
    {
        ForceManager.Providers.Add(this);
    }

    public override void ApplyFrameForce(ForceObject mb)
    {
        if (mb.rb.mass > rb.mass * massCutoff) return;

        pull = transform.position - mb.transform.position;
        pull_mag =  1 * distanceFac / pull.magnitude;
        direction = pull.normalized;

        mb.rb.AddForce(direction * Time.fixedDeltaTime * forceFac * pull_mag);
    }
}