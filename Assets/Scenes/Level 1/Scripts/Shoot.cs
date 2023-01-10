using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject VectorStart;
    [SerializeField] private GameObject VectorEnd;
    [SerializeField] private GameObject Bullet;
    private float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector2 ShootLine = new Vector2(VectorEnd.transform.position.x - VectorStart.transform.position.x, VectorEnd.transform.position.y - VectorStart.transform.position.y);
        if (timer >= 0.2f)
        {
            print(ShootLine);
            GameObject _Bullet = Instantiate(Bullet, VectorStart.transform.position, Quaternion.identity);
            Rigidbody2D bulletbody = _Bullet.GetComponent<Rigidbody2D>();
            bulletbody.velocity = ShootLine.normalized * 10;
            timer = 0;
        }
        
    }
}
