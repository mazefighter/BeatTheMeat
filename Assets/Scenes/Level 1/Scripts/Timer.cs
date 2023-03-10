using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI _text;
    public float timer = 30;
    public int Minute = 1;
    private string displayedtimer;
    public static event Action TimeLose;
    private bool timerstop;
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerstop)
        {
            timer -= Time.deltaTime;
        }
        displayedtimer = timer.ToString("F0");
        if (timer >= 9)
        {
            _text.text = Minute + ":" + displayedtimer;  
        }
        if (timer <= 9)
        {
            _text.text = Minute + ":0" + displayedtimer;
        }
        if (Minute == 0 && timer <= 0)
        {
            TimeLose?.Invoke();
            timerstop = true;
        }
        if (timer <= 0&& Minute >= 1)
        {
            timer = 59;
            Minute--;
        }

        if (timer >= 60)
        {
            float temptimer = timer;
            temptimer -= 60;
            timer = 0;
            timer += temptimer;
            Minute++;
        }

        if (Minute == 0 && timer <= 0)
        {
            TimeLose?.Invoke();
        }
    }
}
