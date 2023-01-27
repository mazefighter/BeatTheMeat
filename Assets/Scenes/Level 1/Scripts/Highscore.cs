using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    private TextMeshProUGUI _text;
    public int highscore;

    private void OnEnable()
    {
        Enemy.HighscoreUpEnemy += EnemyOnHighscoreUpEnemy;
        CageDespawn.HighscoreUpCage += CageDespawnOnHighscoreUpCage;
    }

    private void CageDespawnOnHighscoreUpCage()
    {
        highscore += 500;
    }

    private void OnDisable()
    {
        Enemy.HighscoreUpEnemy -= EnemyOnHighscoreUpEnemy;
        CageDespawn.HighscoreUpCage -= CageDespawnOnHighscoreUpCage;
    }

    private void EnemyOnHighscoreUpEnemy()
    {
        highscore += 20;
    }

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "" + highscore;
    }
}
