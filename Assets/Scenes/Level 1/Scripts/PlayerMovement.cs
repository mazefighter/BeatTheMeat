using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float movespeed;
    public bool OnLadder = false;
    public bool groundcheck = false;
    private float timer = 0.5f;
    private Animator anim;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float inputX = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(inputX*movespeed,0);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Walking",true);
        }
        else
        {
            anim.SetBool("Walking",false);
        }
        if (OnLadder)
        {
            
            float inputY = Input.GetAxis("Vertical");
            _rigidbody2D.velocity = new Vector2(inputX*movespeed, inputY*(movespeed/2));

        }

        if (!OnLadder && !groundcheck)
        {
            timer += Time.deltaTime;
            _rigidbody2D.velocity = new Vector2(inputX*movespeed,Vector2.down.y * movespeed)* timer;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            groundcheck = true;
            timer = 0.5f;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        groundcheck = false;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
