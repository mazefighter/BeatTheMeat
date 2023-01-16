using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject VectorStart;
    [SerializeField] private GameObject VectorEnd;
    [SerializeField] private float lerpspeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 dist = new Vector2(VectorEnd.transform.position.x - VectorStart.transform.position.x,VectorEnd.transform.position.y-VectorStart.transform.position.y);
        Vector2 middle = dist / 2;
        float middlex = VectorEnd.transform.position.x - middle.x;
        float middley = VectorEnd.transform.position.y - middle.y;
        Vector3 targetpos = new Vector3(middlex,middley,transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetpos, lerpspeed*Time.deltaTime);
    }
}
