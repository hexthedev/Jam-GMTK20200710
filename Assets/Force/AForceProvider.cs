using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AForceProvider : MonoBehaviour
{
    public abstract void ApplyFrameForce(Rigidbody2D mb);
}
