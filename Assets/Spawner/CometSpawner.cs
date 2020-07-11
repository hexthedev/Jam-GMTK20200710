using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometSpawner : MonoBehaviour
{
    public ForceObject obj;

    public Vector2 boundTopLeft;
    public Vector2 bountBottomRight;

    public float spawnRateMin = 1;
    public float spawnRateMax = 5;

    public float targetTime = 1;

    public float minMass = 0.2f;
    public float maxMass = 5f;

    public float time = 0;

    public void Update()
    {
        time += Time.deltaTime;

        if(time >= targetTime)
        {
            time = 0;
            targetTime = Random.Range(spawnRateMin, spawnRateMax);

            ForceObject inst = Instantiate(obj, transform);

            Vector2 spawn = new Vector2(
                Random.Range(boundTopLeft.x, bountBottomRight.x),
                Random.Range(boundTopLeft.y, bountBottomRight.y)
            );
            inst.transform.position = spawn;
            inst.Initalize(Random.Range(minMass, maxMass));
        }
    }
}
