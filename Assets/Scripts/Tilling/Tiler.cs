using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class Tiler : MonoBehaviour
{
    public Sprite tile;
    public float tileSize;

    public Transform tileRelativeReference;

    public GameObject[] tileGos = new GameObject[15];

    [Header("Debug")]
    public Vector2 diff;
    public float xMove;
    public float yMove;

    public void Start()
    {
        int index = 0;
        for(float i = -tileSize*2; i<= tileSize*2; i+= tileSize)
        {
            for (float j = -tileSize; j <= tileSize; j += tileSize)
            {
                GameObject ob = new GameObject($"tile({i}, {j})");
                ob.transform.SetParent(transform);
                ob.transform.position = new Vector3(i, j, 1);
                ob.AddComponent<SpriteRenderer>().sprite = tile;
                tileGos[index++] = ob;
            }
        }
    }

    public void Update()
    {
        diff = tileRelativeReference.transform.position - transform.position;

        xMove = Mathf.Abs(diff.x) >= tileSize ? tileSize * Mathf.Sign(diff.x) : 0;
        yMove = Mathf.Abs(diff.y) >= tileSize ? tileSize * Mathf.Sign(diff.y) : 0;

        transform.position += new Vector3(xMove, yMove);

    }





}
