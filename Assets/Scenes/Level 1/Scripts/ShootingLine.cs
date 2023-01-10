using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLine : MonoBehaviour
{
    [SerializeField] private GameObject End;
    [SerializeField] private GameObject _Start;
    private LineRenderer _line;
    void Start()
    {
        _line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _line.SetPosition(0,_Start.transform.position);
        _line.SetPosition(1,End.transform.position);
    }
}
