using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public MonoBehaviour followTarget;
    public float speedFactor;
    public Vector3 modVec;

    private void FixedUpdate()
    {
        Vector3 vec = followTarget.transform.position - transform.position;
        modVec = vec * speedFactor;

        transform.position += new Vector3(modVec.x, modVec.y, 0) * Time.fixedDeltaTime;
    }
}
