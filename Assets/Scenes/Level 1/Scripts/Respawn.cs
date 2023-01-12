using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private TargetDummie _target;
    public float timer;
    private int _type;
    private GameObject _game;
    private bool respawn = false;

    private void OnEnable()
    {
        _target._Respawn += TargetOn_Respawn;
    }

    private void OnDisable()
    {
        _target._Respawn -= TargetOn_Respawn;
    }

    private void TargetOn_Respawn(int type,GameObject gameObject)
    {
        _game = gameObject;
        _type = type;
        respawn = true;
        
        _target.currenthealth = _target.maxhealth;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (respawn && timer >= _type)
        {
            _game.SetActive(true);
        }
        timer += Time.deltaTime;
        
    }
}
