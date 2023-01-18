using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    [SerializeField] private GameObject SpriteObj;
    private SpriteRenderer _renderer;
    [SerializeField] private Sprite DeadBurger;
    [SerializeField]private Animator _animator;
    private void OnEnable()
    {
        Enemy.positionbroadcast += EnemyOnpositionbroadcast;
        _renderer = SpriteObj.GetComponent<SpriteRenderer>();
    }

    private void OnDisable()
    {
        Enemy.positionbroadcast -= EnemyOnpositionbroadcast;
    }

    private void EnemyOnpositionbroadcast(Transform position)
    {
        Instantiate(SpriteObj,position.position,Quaternion.identity);
        _renderer.sprite = DeadBurger;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
