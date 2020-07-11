using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class BlackHoleControl : MonoBehaviour
{
    public float speedFac = 1;
    public Rigidbody2D body;
    public Vector2 input;
    public FixedPuller puller;

    [Header("Collision options")]
    public float scaleScale = 0.1f;
    public float massScale = 0.1f;
    public float pullScale = 1f;
    public float distancePullScale = 2f;

    public float collisionDampen = 0.90f;

    [Header("Stats")]
    public BlackHoleStats stats;

    [Header("Debug")]
    public bool isPaused = false;
    public Vector2 cachedVelo;

    public void OnMove(CallbackContext cont)
    {
        if (cont.canceled)
        {
            input = Vector2.zero;
        } else
        {
            input = cont.ReadValue<Vector2>();
        } 
    }

    private void FixedUpdate()
    {
        body.AddForce(input * speedFac * body.mass );
    }

    public void Pause()
    {
        if (isPaused) return;

        cachedVelo = body.velocity;
        body.velocity = Vector2.zero;
        isPaused = true;
    }

    public void UnPause()
    {
        if (!isPaused) return;

        body.velocity = cachedVelo;
        isPaused = false;
    }

    public void RecieveMass(float ms)
    {
        float sc = ms * scaleScale;
        transform.localScale += new Vector3(sc, sc, sc);

        body.mass += ms * massScale;
        puller.forceFac += ms * pullScale;
        puller.distanceFac += ms * distancePullScale;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    //private void OnCollisionEnter2D(Collision2D collision)
    {
        //ForceObject col = collision.gameObject.GetComponent<ForceObject>();

        //float ms = col.rb.mass;
        //RecieveMass(ms);

        //Destroy(collision.gameObject);
        //stats.Impact(col.rb.mass);

        //List<ContactPoint2D> contacts = new List<ContactPoint2D>();
        //collision.GetContacts(contacts);

        //// Attempt to dampen stof
        //foreach(ContactPoint2D cp2 in contacts)
        //{
        //    body.AddForce(cp2.normalImpulse * -cp2.normal * collisionDampen, ForceMode2D.Impulse);
        //}
    }
}
