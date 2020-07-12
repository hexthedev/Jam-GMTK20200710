using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceScale : MonoBehaviour
{
    public Transform scaleBase;

    public float originalScale;
    public float originalBaseScale;

    private void Start()
    {
        originalScale = transform.localScale.x;
        originalBaseScale = scaleBase.localScale.x;
    }

    void Update()
    {
        float currentScaleBase = scaleBase.localScale.x / originalBaseScale;
        float newScale = originalScale / currentScaleBase;

        transform.localScale = new Vector3(newScale, newScale);
    }
}
