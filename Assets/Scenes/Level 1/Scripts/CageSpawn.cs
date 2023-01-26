using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CageSpawn : MonoBehaviour
{
    private Transform[] cagepositions;
    [SerializeField]private List<GameObject> Cages;
    public bool spawncage = true;
    [SerializeField]private Arrow _arrow;
    [SerializeField] private Timer _timer;
    void Start()
    {
       cagepositions= GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawncage)
        {
            Transform newcagepos = cagepositions[Random.Range(0, cagepositions.Length)];
            GameObject newcageobj = Cages[Random.Range(0, Cages.Count)];
            Instantiate(newcageobj, newcagepos.position, Quaternion.identity);
            _timer.timer += 10;
            _arrow.targetpos = newcagepos.position;
            spawncage = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            spawncage = true;
        }
    }
}
