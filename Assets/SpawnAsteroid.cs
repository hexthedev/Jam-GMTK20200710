using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    public float rate = 1;
    public float range = 10;
    public ForceObject asteroidPre;
    public bool isSpawning = false;

    Coroutine spawnRoutine;

    public void Start()
    {
        spawnRoutine = StartCoroutine(Asteroids());
    }

    IEnumerator Asteroids()
    {
        while (true)
        {
            yield return new WaitForSeconds(rate);

            if (!isSpawning) continue;
            Vector2 rand = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * range;

            ForceObject obj =  Instantiate(asteroidPre);
            obj.transform.position = rand;
        }
    }
}
