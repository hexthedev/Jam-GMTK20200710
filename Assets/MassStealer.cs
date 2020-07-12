using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassStealer : MonoBehaviour
{
    public List<ForceObject> objs;

    public BlackHoleControl cont;
    public float stealRate;

    public void Update()
    {
        ForceObject[] obses = objs.ToArray();
        foreach (ForceObject obs in obses)
        {
            if (obs == null) continue;
            cont.RecieveMass(obs.StealMass(Time.deltaTime * Mathf.Sqrt(cont.body.mass) * stealRate));
        }

        objs.RemoveAll(o => o == null);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        ForceObject obj = collision.gameObject.GetComponent<ForceObject>();
        if (obj == null) return;
        objs.Add(obj);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        ForceObject obj = collision.gameObject.GetComponent<ForceObject>();
        if (obj == null) return;
        objs.Remove(obj);
    }
}
