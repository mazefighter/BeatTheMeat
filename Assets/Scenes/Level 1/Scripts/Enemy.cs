using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] GameObject player;
    [SerializeField] private bool groundcheck;
    [SerializeField] private Sprite _BurgerDead;
    private SpriteRenderer _renderer;
    public float maxhealth;
    public float currenthealth;
    private Bullet _bullet;
    private Slider _slide;
    [SerializeField]private int XpAmount;
    private Animator _animator;

    public delegate void EnemyXP(int XP);
    public static event EnemyXP killed;

    public delegate void DeathPos(Transform position);

    public static event DeathPos positionbroadcast;
    
    void Start()
    {
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        _slide = GetComponentInChildren<Slider>();
        player = GameObject.FindWithTag("Player");
        currenthealth = maxhealth;
        Physics.IgnoreLayerCollision(6,7);
    }

    // Update is called once per frame
    void Update()
    {
        float slidevalue;
        slidevalue = (1 / maxhealth) * currenthealth;
        _slide.value = slidevalue;
        if (currenthealth <= 0)
        {
            killed?.Invoke(XpAmount);
            positionbroadcast?.Invoke(transform);
            Destroy(gameObject);
        }
        if (groundcheck)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.velocity = new Vector2(player.transform.position.x - transform.position.x,transform.position.y).normalized *3;
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.velocity = Vector2.down*5;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")||other.gameObject.CompareTag("Enemy"))
        {
            groundcheck = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            groundcheck = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _bullet = other.GetComponent<Bullet>();
        if (other.gameObject.CompareTag("Bullet"))
        {
            currenthealth -= _bullet.damage;
        }
        
    }
    
}