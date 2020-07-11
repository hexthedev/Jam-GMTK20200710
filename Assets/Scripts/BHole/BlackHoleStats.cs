using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlackHoleStats : MonoBehaviour
{
    Coroutine happinessCounter;

    public float lonliness;
    public float accumulation;

    public float togethernessMax = 10000;

    [Tooltip("Exponential Cutoff")]
    public float happyDistSq;

    public float lonliLossPerSecond = 100;
    public float lonliLossPerImpactMass = 500;

    public float timeAlive;

    [Header("UI")]
    public TextMeshProUGUI _value;
    public TextMeshProUGUI _timer;
    public Slider _slider; 

    public void Start()
    {
        happinessCounter = StartCoroutine(LonlinessRoutine());
    }

    public void FixedUpdate()
    {
        foreach(ForceObject fo in ForceManager.ForceReceivers)
        {
            if (fo == null) continue;

            float mag = (fo.transform.position - transform.position).sqrMagnitude;
            float hap = -mag + happyDistSq;

            if (hap > 0) accumulation += hap * Time.fixedDeltaTime * fo.rb.mass;
        }

        timeAlive += Time.fixedDeltaTime;
    }

    public void Impact(float mass)
    {
        UpdateLonlines(-lonliLossPerImpactMass * mass);
        UpdateLonlinessUI();
    }

    IEnumerator LonlinessRoutine()
    {
        while (true)
        {
            UpdateLonlines(accumulation - lonliLossPerSecond);
            accumulation = 0;

            UpdateLonlinessUI();

            yield return new WaitForSeconds(1);
        }
    }

    public void UpdateLonlines(float lone)
    {
        lonliness += lone;
        lonliness = Mathf.Clamp(lonliness, 0, togethernessMax);
    }

    public void UpdateLonlinessUI()
    {
        _value.text = $"{Mathf.Round(lonliness)}";
        _slider.value = lonliness / togethernessMax;

    }
}
