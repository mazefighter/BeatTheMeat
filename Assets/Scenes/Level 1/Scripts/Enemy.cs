using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D coll;
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
    private PlayerStats _stats;
    public float timer;
    public bool moveRight;

    public float enemySpeed ;
    //private CameraShake _shake;

    public delegate void EnemyXP(int XP);
    public static event EnemyXP killed;
    public static event Action HighscoreUpEnemy;

    public delegate void DeathPos(Transform position);

    public static event DeathPos positionbroadcast;
    [SerializeField] private Transform groundchecktrans;
    [SerializeField] private LayerMask groudlayer;

    private bool isGrounded;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        _slide = GetComponentInChildren<Slider>();
        player = GameObject.FindWithTag("Player");
        _stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        _stats.Stop += StatsOnStop;
        //_shake = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
        currenthealth = maxhealth;
        Physics.IgnoreLayerCollision(6,6,false);
        Physics.IgnoreLayerCollision(6,7,false);
    }

    private void OnDisable()
    {
        _stats.Stop -= StatsOnStop;
    }

    private void StatsOnStop()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 30)
        {
            Destroy(gameObject);
        }
    }

    private void GroundCheck()
    {
        Bounds bounds = coll.bounds;
        Vector2 size = new Vector2(bounds.extents.x + bounds.extents.x / 2, 0.05f);
        Vector2 origin = new Vector2(bounds.center.x, bounds.center.y - bounds.extents.y);
        isGrounded = Physics2D.OverlapCapsule(origin, size, CapsuleDirection2D.Horizontal, 0f, groudlayer);
    }
    
    void Update()
    {
        GroundCheck();
        if (transform.position.x - player.transform.position.x <= 0.1 &&
            transform.position.x - player.transform.position.x >= -0.1)
        {
            moveRight = true;
        }
        int i = Random.Range(0, 11);
        timer += Time.deltaTime;
        float slidevalue;
        slidevalue = (1 / maxhealth) * currenthealth;
        _slide.value = slidevalue;
        if (currenthealth <= 0)
        {
            HighscoreUpEnemy?.Invoke();
            killed?.Invoke(XpAmount);
            positionbroadcast?.Invoke(transform);
            Destroy(gameObject);
        }
        if (isGrounded)
        {
            Seek(player.transform.position);

        }
        else
        {
            moveRight = false;
        }
        
    }

    private void Seek(Vector3 destination)
    {
        if (moveRight)
        {
            _rigidbody2D.velocity = Vector2.right.normalized * enemySpeed;
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(destination.x - transform.position.x, 0).normalized*enemySpeed;
        }
        
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        _bullet = other.GetComponent<Bullet>();
        if (other.gameObject.CompareTag("Bullet"))
        {
           // _shake.shake = 1f;
            currenthealth -= _bullet.damage;
        }
    }
    
}
