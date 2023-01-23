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
    private PolygonCollider2D _collider;
    [SerializeField] private Shoot _shoot;
    private static readonly int Climbing = Animator.StringToHash("Climbing");
    private static readonly int Walking = Animator.StringToHash("Walking");
    private static readonly int Hanging = Animator.StringToHash("Hanging");
    [SerializeField] XpBar _levelUp;
    [SerializeField] private GameObject lvl;
    private bool pause = false;
    [SerializeField] private PlayerStats _stats;

    private void OnEnable()
    {
        _levelUp.levelUp += LevelUpOnlevelUp;
        _stats.Stop += StatsOnStop;
    }

    private void StatsOnStop()
    {
        _rigidbody2D.velocity = Vector2.zero;
        pause = true;
        anim.SetBool(Hanging, false);
        anim.SetBool(Climbing, false);
        anim.SetBool("Walking",false);
    }

    private void OnDisable()
    {
        _levelUp.levelUp -= LevelUpOnlevelUp;
        _stats.Stop -= StatsOnStop;
    }

    private void LevelUpOnlevelUp()
    {
        Instantiate(lvl,transform.position, Quaternion.identity);
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _collider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        if (!pause)
        {
            _shoot.shoot = true;
            _rigidbody2D.velocity = Vector2.zero;
            
            _rigidbody2D.velocity = new Vector2(inputX*movespeed,0);
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                anim.SetBool(Hanging, false);
                anim.SetBool(Climbing, false);
                anim.SetBool("Walking",true);
            }
            else
            {
                anim.SetBool("Walking",false);
            }
            if (OnLadder)
            {
                float inputY = Input.GetAxis("Vertical");
                _rigidbody2D.velocity = new Vector2(inputX * movespeed, inputY*(movespeed/2));
                
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                {
                    anim.SetBool(Walking, false);
                    anim.SetBool(Hanging, false);
                    anim.SetBool(Climbing, true);
                    _shoot.shoot = false;
                }
                else if (!groundcheck)
                {
                    anim.SetBool(Walking, false);
                    anim.SetBool(Climbing, false);
                    anim.SetBool(Hanging, true);
                }
            }

            if (!OnLadder)
            {
                anim.SetBool("Climbing",false);
            }

            
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
            _rigidbody2D.velocity = Vector2.zero;
            OnLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            OnLadder = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")|| !OnLadder)
        {
            groundcheck = true;
            timer = 0.5f;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")||other.gameObject.CompareTag("Enemy"))
        {
            groundcheck = false; 
        }
        _rigidbody2D.velocity = Vector2.zero;
    }
}
