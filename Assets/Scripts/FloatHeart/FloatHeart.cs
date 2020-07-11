using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatHeart : MonoBehaviour
{
    public Transform target;
    public Transform origin;

    public float journey;

    public void FixedUpdate()
    {
        if (journey >= 1 || target == null || origin == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 newpos = origin.position + ((target.transform.position - origin.transform.position) * journey);
        transform.position = newpos;
        journey += Time.fixedDeltaTime;
    }
}
