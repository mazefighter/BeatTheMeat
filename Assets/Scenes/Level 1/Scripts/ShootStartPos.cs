using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootStartPos : MonoBehaviour
{
    [SerializeField] private GameObject mousePos;
    private Vector3 distancePlayerMouse;
    [SerializeField]private GameObject Player;
    public float Xpos;
    public float Ypos;
    private bool pause = false;
    [SerializeField] private PlayerStats _stats;

    private void OnEnable()
    {
        _stats.Stop += StatsOnStop;
    }

    private void OnDisable()
    {
        _stats.Stop -= StatsOnStop;
    }

    private void StatsOnStop()
    {
        pause = true;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            distancePlayerMouse = new Vector3(mousePos.transform.position.x - Player.transform.position.x,mousePos.transform.position.y - Player.transform.position.y,0);
            if (distancePlayerMouse.x < 0)
            {
                if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
                {
                    transform.position = new Vector2(Player.transform.position.x - Xpos - 0.3f , Player.transform.position.y +Ypos);
                }
                transform.position = new Vector2(Player.transform.position.x - Xpos , Player.transform.position.y +Ypos);
                Player.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            if (distancePlayerMouse.x > 0)
            {
                if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
                {
                    transform.position = new Vector2(Player.transform.position.x - Xpos + 0.3f , Player.transform.position.y +Ypos);
                }
                transform.position = new Vector2(Player.transform.position.x + Xpos , Player.transform.position.y +Ypos);
                Player.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
        
        
    }
}
