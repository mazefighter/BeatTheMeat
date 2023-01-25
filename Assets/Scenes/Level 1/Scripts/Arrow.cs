using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]private Vector3 targetpos;
    [SerializeField]private Transform originpos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (originpos.position.y < targetpos.y)
        {
            Vector3 connect = targetpos - originpos.position;
            float angle = Vector3.Angle(Vector3.right, connect);
            transform.rotation = Quaternion.Euler(0,0,angle);
        }
       

        if (originpos.position.y > targetpos.y)
        {
            Vector3 connect = targetpos - originpos.position;
            float angle = Vector3.Angle(Vector3.right, connect);
            transform.rotation = Quaternion.Euler(0,0,-angle);
        }
    }
}
