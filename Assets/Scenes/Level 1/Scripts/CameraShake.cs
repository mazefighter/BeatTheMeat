using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    private float decreaseFactor = 1.0f;
    private float shakeAmount = 0.2f;
    public float shake = 0;
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update() {
        if (shake > 0) {
            _camera.transform.position = new Vector3( Random.insideUnitSphere.x  * shakeAmount, Random.insideUnitSphere.y  * shakeAmount, _camera.transform.position.z);
            shake -= Time.deltaTime * decreaseFactor;
            
 
        } else {
            shake = 0.0f;
        }
    }
}
