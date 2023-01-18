using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject Burger;
    float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer > 1)
        {
            Instantiate(Burger, transform.position, Quaternion.identity);
            timer = 0;
        }
        
    }
}
