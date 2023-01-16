using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private TargetDummie _target;
    public float timer;
    private int _type;
    private bool respawn = false;
    private BoxCollider2D _collider;
    private SpriteRenderer _renderer;
    public bool reactivate;

    void Start()
    {
        _collider = GetComponentInParent<BoxCollider2D>();
        _renderer = GetComponentInParent<SpriteRenderer>();
        _target = GetComponentInParent<TargetDummie>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_target._doRespawn)
        {
            timer = 0;
            respawn = true;
            _target.currenthealth = _target.maxhealth;
            _target._doRespawn = false;
            
        }
        if (respawn && timer >= _target._EnemyType)
        {
            reactivate = true;
            respawn = false;
            timer = 0;
        }
        timer += Time.deltaTime;
        
    }
}
