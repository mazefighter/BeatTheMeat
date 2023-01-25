using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lengthX, startposX,lengthY,startposY;
    [SerializeField] private GameObject cam;
    public float parallaxEffect;
    void Start()
    {
        startposX = transform.position.x;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        startposY = transform.position.y;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distX = (cam.transform.position.x * parallaxEffect);
        float distY = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(startposX + distX, startposY + distY, transform.position.z);

        if (temp > startposX + lengthX)
        {
            startposX += lengthX;
        }
        else if (temp < startposX - lengthX)
        {
            startposX -= lengthX;
        }
    }
}
