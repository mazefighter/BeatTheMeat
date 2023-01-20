using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenüOpen : MonoBehaviour
{
    private Animator _animator;
    private Image _renderer;
    [SerializeField] private GameObject Buttons;
    public bool opened;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            _animator.SetTrigger("Open");
        }

        if (opened)
        {
            Buttons.SetActive(true);
        }
    }
}
