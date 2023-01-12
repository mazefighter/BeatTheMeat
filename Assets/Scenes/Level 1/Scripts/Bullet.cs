using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float timer = 0;
    [SerializeField] public float damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Ladder")&& !other.gameObject.CompareTag("Player")&&!other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); 
        }
    }
}
