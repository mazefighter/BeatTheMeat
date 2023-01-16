using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class TargetDummie : MonoBehaviour
{
    private Bullet _bullet;
    public float maxhealth;
    public float currenthealth;
    private Slider _slide;
    private Respawn _spawn;
    public int _EnemyType;
    public bool _doRespawn = false;
    public bool _startTimer;
    private BoxCollider2D _collider;
    private SpriteRenderer _renderer;
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _spawn = GetComponentInChildren<Respawn>();
        _slide = GetComponentInChildren<Slider>();
        currenthealth = maxhealth;
    }
    void Update()
    {
        float slidevalue;
        slidevalue = (1 / maxhealth) * currenthealth;
        _slide.value = slidevalue;

        if (currenthealth <= 0)
        {
            _doRespawn = true;
            _spawn.timer = 0;
            _renderer.enabled = !_renderer.enabled;
            _collider.enabled = !_collider.enabled;
            _slide.gameObject.SetActive(false);
        }

        if (_spawn.reactivate)
        {
            _renderer.enabled = true;
            _collider.enabled = true;
            _slide.gameObject.SetActive(true);
            _spawn.reactivate = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _bullet = other.GetComponent<Bullet>();
        if (other.gameObject.CompareTag("Bullet"))
        {
            currenthealth -= _bullet.damage;
        }
    }
}

//punktausbasta
