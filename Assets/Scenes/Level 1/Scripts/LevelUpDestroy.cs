using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpDestroy : MonoBehaviour
{
    private float timer;
    private float lvltimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        lvltimer += Time.deltaTime;
        if (lvltimer > 0.1f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y+0.2f, transform.position.z);
            lvltimer = 0;
        }
        if (timer >= 1)
        {
            Destroy(gameObject);
        }
    }
}
