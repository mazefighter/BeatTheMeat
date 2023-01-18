using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private TextMeshProUGUI _textHP;
    private PlayerStats _stats;
    private Slider _slider;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();
        _stats = Player.GetComponent<PlayerStats>();
        _stats.currenthealth = _stats.maxhealth;
        _textHP.SetText(_stats.currenthealth+" / "+_stats.maxhealth);
        _stats.EnemyCollision += StatsOnEnemyCollision;
        _slider.value = (1 / _stats.maxhealth) * _stats.currenthealth;
    }

    private void OnDisable()
    {
        _stats.EnemyCollision -= StatsOnEnemyCollision;
    }

    private void StatsOnEnemyCollision()
    {
        _stats.currenthealth--;
        _slider.value = (1 / _stats.maxhealth) * _stats.currenthealth;
        _textHP.SetText(_stats.currenthealth+" / "+_stats.maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
