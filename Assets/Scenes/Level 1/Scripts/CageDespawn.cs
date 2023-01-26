using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageDespawn : MonoBehaviour
{
    private CageSpawn _cageSpawn;
    void Start()
    {
        _cageSpawn = GameObject.FindWithTag("CageSpawner").GetComponent<CageSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _cageSpawn.spawncage = true;
            Destroy(gameObject);
        }
    }
}
