using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject VectorStart;
    [SerializeField] private GameObject VectorEnd;
    [SerializeField] private float lerpspeed;
    [SerializeField] private PlayerStats _stats;
    private bool stop;

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
        stop = true;
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), 2*Time.deltaTime);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!stop)
        {
            Vector2 dist = new Vector2(VectorEnd.transform.position.x - VectorStart.transform.position.x,VectorEnd.transform.position.y-VectorStart.transform.position.y);
            Vector2 middle = dist / 2;
            float middlex = VectorEnd.transform.position.x - middle.x;
            float middley = VectorEnd.transform.position.y - middle.y;
            Vector3 targetpos = new Vector3(middlex,middley,transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetpos, lerpspeed*Time.deltaTime);
        }
        
    }
}
