using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    private float timer = 0;
    [SerializeField] public float damage;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(0,0,Random.Range(0,360));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            damage = 6;
        }

        timer += Time.deltaTime;
        if (timer > 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Ladder")&& !other.gameObject.CompareTag("Player")&&!other.gameObject.CompareTag("SpawnArea")&&!other.gameObject.CompareTag("Untagged"))
        {
            Destroy(gameObject); 
        }
    }
}
