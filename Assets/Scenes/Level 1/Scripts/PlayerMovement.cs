using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float movespeed;
    private bool OnLadder = false;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(inputX*movespeed,0);
        if (OnLadder)
        {
            float inputY = Input.GetAxis("Vertical");
            _rigidbody2D.velocity = new Vector2(inputX*movespeed, inputY*(movespeed/2));

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            OnLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        OnLadder = false;
    }
}
