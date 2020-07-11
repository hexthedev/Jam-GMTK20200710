using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawner : MonoBehaviour
{
    [Header("Prefab")]
    public ForceObject obj;

    [Header("Bounds")]
    public Vector2 boundTopLeft;
    public Vector2 bountBottomRight;

    [Header("Options")]
    public float spawnRateMin = 1;
    public float spawnRateMax = 5;

    public float minMass = 0.2f;
    public float maxMass = 5f;

    public float clusterSize = 1;
    public float clusterSpread = 0.2f;

    [Header("Debugger")]
    public float time = 0;
    public float targetTime = 0;

    public void Update()
    {
        time += Time.deltaTime;

        if(time >= targetTime)
        {
            time = 0;
            targetTime = Random.Range(spawnRateMin, spawnRateMax);

            Vector2 spawn = new Vector2(
                Random.Range(boundTopLeft.x, bountBottomRight.x),
                Random.Range(boundTopLeft.y, bountBottomRight.y)
            );

            for (int i = 0; i<clusterSize; i++)
            {
                ForceObject inst = Instantiate(obj, transform);

                inst.transform.position = spawn;
                inst.Initalize(Random.Range(minMass, maxMass));

                spawn += new Vector2(Random.Range(0, clusterSpread), Random.Range(0, clusterSpread));
            }
        }
    }
}
