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
    public float scaleIncrease = 0.1f;
    public float massIncrease = 0.1f;
    public float pullIncrease = 1f;
    public float distancePullIncrease = 2f;

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
        body.AddForce(input * speedFac);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.localScale += new Vector3(scaleIncrease, scaleIncrease, scaleIncrease);
        body.mass += massIncrease;
        puller.forceFac += pullIncrease;
        puller.distanceFac += distancePullIncrease;

        Destroy(collision.gameObject);
    }
}
