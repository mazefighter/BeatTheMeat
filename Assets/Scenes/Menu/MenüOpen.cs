using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenüOpen : MonoBehaviour
{
    private Animator _animator;
    private Image _renderer;
    [SerializeField] Sprite openMenu;
    private float timer;
    [SerializeField] private GameObject Buttons;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.anyKey)
        {
            _animator.SetTrigger("Open");
            _renderer.sprite = openMenu;
            Buttons.SetActive(true);
        }
        
    }
}
