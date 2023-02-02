using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float maxhealth;
    public float currenthealth;
    public event Action EnemyCollision;
    private float timer;
    private Animator _animator;
    private float deathTimer;
    [SerializeField] private Shoot _shoot;
    private bool timelose;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _timesUp;
    [SerializeField] private Sprite _youDied;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private AudioSource _loseSound;
    [SerializeField] private AudioSource _backgroundSound;

    public event Action Stop;

    private void OnEnable()
    {
        Timer.TimeLose += TimerOnTimeLose;
    }

    private void OnDisable()
    {
        Timer.TimeLose -= TimerOnTimeLose;
    }

    private void TimerOnTimeLose()
    {
        timelose = true;
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (currenthealth <= 0)
        {
            _animator.SetBool("Death",true);
            _shoot.shoot = false;
            Stop?.Invoke();
            deathTimer += Time.deltaTime;
            if (deathTimer > 3)
            {
                _backgroundSound.Stop();
                _loseSound.enabled = true;
                _image.sprite = _youDied;
                endScreen.SetActive(true);
                if (Input.anyKey)
                {
                    SceneManager.LoadScene("Menu");
                }
            }
            
        }
        if (timelose)
        {
            _animator.SetBool("Death",true);
            _shoot.shoot = false;
            Stop?.Invoke();
            deathTimer += Time.deltaTime;
            if (deathTimer > 3)
            {
                _image.sprite = _timesUp;
                endScreen.SetActive(true);
                _backgroundSound.Stop();
                _loseSound.enabled = true;
                if (Input.anyKey)
                {
                    SceneManager.LoadScene("Menu");
                }
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        timer = 0;
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyCollision?.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")&&timer>0.5)
        {
            EnemyCollision?.Invoke();
            timer = 0;
        }
    }
}
