using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlackHoleStats : MonoBehaviour
{
    //Coroutine happinessCounter;

    [Header("Old")]
    public float lonliness;
    public float accumulation;
    public float togethernessMax = 10000;
    public float lonliLossPerSecond = 100;
    public float lonliLossPerImpactMass = 500;

    [Header("Love")]
    public float loveDistance;
    public float loveChance;
    public float loveAttemptSeconds;
    public float love;
    public TextMeshProUGUI loveValUI;
    public FloatHeart floatHeart;

    [Header("Mass")]
    public float stealDistance;
    public float stealAttemptSeconds;
    public float stealChance;
    public TextMeshProUGUI massScore;

    public FloatHeart massSteal;
    public BlackHoleControl cont;

    [Tooltip("Exponential Cutoff")]
    public float happyDistSq;

    [Tooltip("Time")]
    public float timeAlive;

    [Header("UI")]
    public TextMeshProUGUI _value;
    public TextMeshProUGUI _timer;
    public Slider _slider;
    public GameObject gameover;

    public void Start()
    {
        StartCoroutine(UpdateLove());
        StartCoroutine(UpdateSteal());
    }

    public void FixedUpdate()
    {
        // Time Alive
        timeAlive += Time.fixedDeltaTime;
        float minutes = timeAlive / 60;
        _timer.text = $"{Mathf.Floor(minutes)} : {(Mathf.Floor(timeAlive) % 60).ToString("00")}";
    }

    IEnumerator UpdateLove()
    {
        while (true)
        {
            yield return new WaitForSeconds(loveAttemptSeconds);

            foreach (ForceObject fo in ForceManager.ForceReceivers)
            {
                if (fo == null) continue;
                float mag = (fo.transform.position - transform.position).magnitude;
                float scale = transform.localScale.x;

                float inLoveDistance = -mag + loveDistance + cont.body.mass;
                if (inLoveDistance > 0)
                {
                    if (Random.Range(0, 100f) <= loveChance)
                    {
                        FloatHeart fh = Instantiate(floatHeart, transform);
                        fh.origin = transform;
                        fh.target = fo.transform;
                        fh.onEnd = () =>
                        {
                            if (fo != null && fo.rb != null)
                            {
                                love += fo.rb.mass;
                                loveValUI.text = $"{Mathf.Round(love)}";
                            }
                        };
                    }
                }
            }
        }
    }

    IEnumerator UpdateSteal()
    {
        while (true)
        {
            yield return new WaitForSeconds(stealAttemptSeconds);

            foreach (ForceObject fo in ForceManager.ForceReceivers)
            {
                if (fo == null) continue;
                float mag = (fo.transform.position - transform.position).magnitude;
                float scale = transform.localScale.x; // distances are modified by scale

                float inStealDistance = -mag + stealDistance + cont.body.mass;
                if (inStealDistance > 0)
                {
                    if (Random.Range(0, 100f) <= stealChance)
                    {
                        //float close = 1 - inStealDistance / (stealDistance + scale); // larger when closer

                        float massToSteal = 1f;
                        fo.StealMass(massToSteal);

                        FloatHeart f = Instantiate(massSteal);
                        f.origin = fo.transform;
                        f.target = transform;
                        //f.transform.localScale = Vector3.one * massToSteal;

                        f.onEnd = () =>
                        {
                            cont.RecieveMass(massToSteal);
                            massScore.text = $"{Mathf.Round(cont.body.mass)}";
                        };
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * (loveDistance + cont.body.mass));
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * (stealDistance + cont.body.mass));

    }

    //public void Impact(float mass)
    //{
    //    UpdateLonlines(-lonliLossPerImpactMass * mass);
    //    UpdateLonlinessUI();
    //}

    //IEnumerator UpdateRoutine()
    //{
    //    while (true)
    //    {
    //UpdateLonlines(accumulation - lonliLossPerSecond);
    //accumulation = 0;

    //UpdateLonlinessUI();

    // Love
    //love += loveacc;
    //loveacc = 0;
    //loveValUI.text = $"{Mathf.Round(love)}";

    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}

    //public void UpdateLonlines(float lone)
    //{
    //    lonliness += lone;
    //    lonliness = Mathf.Clamp(lonliness, 0, togethernessMax);
    //    //if (lonliness <= 0) gameover.SetActive(true);
    //}

    //public void UpdateLonlinessUI()
    //{
    //    _value.text = $"{Mathf.Round(lonliness)}";
    //    _slider.value = lonliness / togethernessMax;
    //}
}
