using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    [SerializeField] private List<GameObject> SpriteObj;
    private SpriteRenderer _renderer;
    [SerializeField] private List<Sprite> DeadBurger;
    private void OnEnable()
    {
        Enemy.positionbroadcast += EnemyOnpositionbroadcast;
        
    }

    private void OnDisable()
    {
        Enemy.positionbroadcast -= EnemyOnpositionbroadcast;
    }

    private void EnemyOnpositionbroadcast(Transform position, int Type)
    {
        if (Type == 1)
        {
            _renderer = SpriteObj[0].GetComponent<SpriteRenderer>();
            Instantiate(SpriteObj[0],position.position,Quaternion.identity);
            _renderer.sprite = DeadBurger[0]; 
        }
        if (Type == 2)
        {
            _renderer = SpriteObj[1].GetComponent<SpriteRenderer>();
            Instantiate(SpriteObj[1],position.position,Quaternion.identity);
            _renderer.sprite = DeadBurger[1];
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
