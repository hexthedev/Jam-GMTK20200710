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

    public float loveacc;
    public float love;
    public TextMeshProUGUI loveValUI;
    public FloatHeart floatHeart;

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
    public GameObject gameover;

    public void Start()
    {
        happinessCounter = StartCoroutine(UpdateRoutine());
    }

    public void FixedUpdate()
    {
        // Love
        foreach(ForceObject fo in ForceManager.ForceReceivers)
        {
            if (fo == null) continue;

            float mag = (fo.transform.position - transform.position).sqrMagnitude;
            float hap = -mag + happyDistSq;

            if (hap > 0) accumulation += hap * Time.fixedDeltaTime * fo.rb.mass;
        }


        // Time Alive
        timeAlive += Time.fixedDeltaTime;
        float minutes = timeAlive / 60;
        _timer.text = $"{Mathf.Floor(minutes)} : {(Mathf.Floor(timeAlive)%60).ToString("00")}";

        // Love
        foreach (ForceObject fo in ForceManager.ForceReceivers)
        {
            if (fo == null) continue;

            float mag = (fo.transform.position - transform.position).sqrMagnitude;
            float hap = -mag + happyDistSq;

            if (hap > 0)
            {
                //loveacc += hap * Time.fixedDeltaTime * fo.rb.mass;

                if (Random.Range(0, 1f) > 0.99f)
                {
                    love += fo.rb.mass;
                    loveacc = 0;
                    loveValUI.text = $"{Mathf.Round(love)}";

                    FloatHeart fh = Instantiate(floatHeart, transform);
                    fh.origin = transform;
                    fh.target = fo.transform;
                    fh.transform.localScale *= fo.rb.mass;
                }
            }
        }

    }

    public void Impact(float mass)
    {
        UpdateLonlines(-lonliLossPerImpactMass * mass);
        UpdateLonlinessUI();
    }

    IEnumerator UpdateRoutine()
    {
        while (true)
        {
            UpdateLonlines(accumulation - lonliLossPerSecond);
            accumulation = 0;

            UpdateLonlinessUI();

            // Love
            //love += loveacc;
            //loveacc = 0;
            //loveValUI.text = $"{Mathf.Round(love)}";

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void UpdateLonlines(float lone)
    {
        lonliness += lone;
        lonliness = Mathf.Clamp(lonliness, 0, togethernessMax);
        if (lonliness <= 0) gameover.SetActive(true);
    }

    public void UpdateLonlinessUI()
    {
        _value.text = $"{Mathf.Round(lonliness)}";
        _slider.value = lonliness / togethernessMax;
    }
}
