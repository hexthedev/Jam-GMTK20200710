using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlackHoleStats : MonoBehaviour
{
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

    [Tooltip("Time")]
    public float timeAlive;

    [Header("UI")]
    public TextMeshProUGUI _value;
    public TextMeshProUGUI _timer;
    public Slider _slider;
    public GameObject gameover;

    public void FixedUpdate()
    {
        // Time Alive
        timeAlive += Time.fixedDeltaTime;
        float minutes = timeAlive / 60;
        _timer.text = $"{Mathf.Floor(minutes)} : {(Mathf.Floor(timeAlive) % 60).ToString("00")}";
    }
}
