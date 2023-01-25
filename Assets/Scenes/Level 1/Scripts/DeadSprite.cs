using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSprite : MonoBehaviour
{
    private float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 30)
        {
            Destroy(gameObject);
        }
    }
}
