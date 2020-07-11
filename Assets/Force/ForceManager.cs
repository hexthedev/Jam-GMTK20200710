﻿using System.Collections.Generic;
using UnityEngine;

public class ForceManager : MonoBehaviour
{
    public static List<AForceProvider> Providers = new List<AForceProvider>();
    public static List<ForceObject> ForceReceivers = new List<ForceObject>();

    public void FixedUpdate()
    {
        foreach(ForceObject rec in ForceReceivers)
        {
            foreach(AForceProvider pro in Providers)
            {
                if (rec == null || pro == null) continue;
                pro.ApplyFrameForce(rec);
            }
        }

        ForceReceivers.RemoveAll(o => o == null);
    }
}
