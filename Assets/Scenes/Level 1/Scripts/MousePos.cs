using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePos : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector3 Mouse;
    private Vector3 distancePlayerMouse;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Mouse = Input.mousePosition;
        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Mouse).x, Camera.main.ScreenToWorldPoint(Mouse).y);
    }
}
