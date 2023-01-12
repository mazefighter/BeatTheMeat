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
    private float timer;
    private Thread _thread;
    [SerializeField] private Respawn _spawn;

    public delegate void EnemyType(int type, GameObject gameObject);

    public event EnemyType _Respawn;
    private void OnEnable()
    {
        _slide = GetComponentInChildren<Slider>();
        currenthealth = maxhealth;
    }
    

    void Start()
    {
        
    }
    void Update()
    {
        float slidevalue;
        slidevalue = (1 / maxhealth) * currenthealth;
        _slide.value = slidevalue;

        if (currenthealth <= 0)
        {
            _spawn.timer = 0;
            _Respawn?.Invoke(2,gameObject);
            gameObject.SetActive(false);
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
