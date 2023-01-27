using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject Burger;
    [SerializeField] private GameObject Wurst;
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
        if (other.gameObject.CompareTag("SpawnArea")&& !spawned)
        {
            int random = Random.Range(0, 3);
            switch (random)
            {
                case 1:
                    Instantiate(Burger, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Wurst, transform.position, Quaternion.identity);
                    break;
            }
            
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
