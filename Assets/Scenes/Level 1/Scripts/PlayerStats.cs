using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxhealth;
    public float currenthealth;
    public event Action EnemyCollision;
    private float timer;
    private Animator _animator;
    private float deathTimer;
    [SerializeField] private Shoot _shoot;
    public event Action Stop;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (currenthealth <= 0)
        {
            _animator.SetBool("Death",true);
            _shoot.shoot = false;
            Stop?.Invoke();
            deathTimer += Time.deltaTime;
            if (deathTimer > 2.5f)
            {
                Time.timeScale = 0;
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        timer = 0;
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyCollision?.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")&&timer>0.5)
        {
            EnemyCollision?.Invoke();
            timer = 0;
        }
    }
}
