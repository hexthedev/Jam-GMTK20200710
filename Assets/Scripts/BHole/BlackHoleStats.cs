using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlackHoleStats : MonoBehaviour
{
    public static BlackHoleStats instance;

    [Header("Love")]
    public float loveDistance;
    public float loveChance;
    public float loveAttemptSeconds;
    public float love;
    public TextMeshProUGUI loveValUI;
    public FloatHeart floatHeart;
    public GameObject loveTrigger;

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

    public void Awake()
    {
        instance = this;
    }

    public void FixedUpdate()
    {
        // Time Alive
        timeAlive += Time.fixedDeltaTime;
        float minutes = timeAlive / 60;
        _timer.text = $"{Mathf.Floor(minutes)} : {(Mathf.Floor(timeAlive) % 60).ToString("00")}";

        massScore.text = $"{Mathf.Round(cont.body.mass)}";
    }

    public void Update()
    {
        love = Mathf.Clamp(love, -1000, 1000);

        if (love < 0) FaceSwapper.instance.ChangeBaseFace(FaceSwapper.instance.faces.sad);
        if (love > 0) FaceSwapper.instance.ChangeBaseFace(FaceSwapper.instance.faces.happy);


        if (cont.body.mass >= 100 ) loveTrigger.SetActive(false);
        if (cont.body.mass >= 400) gameover.SetActive(true);
    }
}
