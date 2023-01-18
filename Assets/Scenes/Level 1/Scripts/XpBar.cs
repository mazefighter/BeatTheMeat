using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    private Slider _slider;
    [SerializeField]private float XPValue;
    private float currXp;
    private event Action levelUp;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        currXp = 0;
        Enemy.killed += EnemyOnkilled;
        _slider = GetComponent<Slider>();
    }

    private void OnDisable()
    {
        Enemy.killed -= EnemyOnkilled;
    }

    private void EnemyOnkilled(int XP)
    {
        currXp += XP;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currXp >= XPValue)
        {
            levelUp?.Invoke();
            float XpDiff = currXp - XPValue;
            currXp = 0;
            currXp += XpDiff;
        }
        _slider.value = (1 / XPValue) * currXp;
    }
}
