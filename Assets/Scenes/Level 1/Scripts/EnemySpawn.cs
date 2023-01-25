using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject Burger;
    float timer = 0;
    public Transform Target;
 
    public float RotationSpeed = 1;
 
    public float CircleRadius = 1;
 
    public float ElevationOffset = 0;
    public bool spawned = false;
 
    private Vector3 positionOffset;
    private float angle;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        positionOffset.Set(
            Mathf.Cos( angle ) * CircleRadius,
            Mathf.Sin( angle ) * CircleRadius,
            0
        );
        Vector3 newposition = Target.position + positionOffset;
        _rigidbody2D.velocity = newposition - transform.position;
        angle += Time.deltaTime * RotationSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground")&& !spawned)
        {
            Instantiate(Burger, transform.position, Quaternion.identity);
            spawned = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        spawned = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
