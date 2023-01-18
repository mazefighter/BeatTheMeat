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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        timer = 0;
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyCollision?.Invoke();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy")&&timer>0.5)
        {
            EnemyCollision?.Invoke();
            timer = 0;
        }
    }
}
