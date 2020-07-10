using System.Collections.Generic;
using UnityEngine;

public class ForceManager : MonoBehaviour
{
    public static List<AForceProvider> Providers = new List<AForceProvider>();
    public static List<Rigidbody2D> ForceReceivers = new List<Rigidbody2D>();

    public void FixedUpdate()
    {
        foreach(Rigidbody2D rec in ForceReceivers)
        {
            foreach(AForceProvider pro in Providers)
            {
                pro.ApplyFrameForce(rec);
            }
        }
    }
}
