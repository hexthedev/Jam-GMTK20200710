using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public TextMeshProUGUI text;
    public BlackHoleStats stats;

    public void Start()
    {
        float minutes = stats.timeAlive / 60;
        string time = $"{Mathf.Floor(minutes)} minues, {Mathf.Floor(stats.timeAlive)%60} seconds";
        text.text = $"And so it was told, ones nature can never be undone. At least you spent {time} out in the (once), abundant universe";
    }
}
