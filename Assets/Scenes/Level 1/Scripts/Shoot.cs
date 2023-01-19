using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject VectorStart;
    [SerializeField] private GameObject VectorEnd;
    [SerializeField] private GameObject Bullet;
    private float timer = 0;
    public bool shoot = true;
    void Start()
    {
        
    }

    public float speed = 20;

    public float shootAmount = 0.3f;
    // Update is called once per frame
    void Update()
    {
        if (shoot)
        {
            timer += Time.deltaTime;
            Vector2 ShootLine = new Vector2(VectorEnd.transform.position.x - VectorStart.transform.position.x, VectorEnd.transform.position.y - VectorStart.transform.position.y);
            if (timer >= shootAmount)
            {
                GameObject _Bullet = Instantiate(Bullet, VectorStart.transform.position, Quaternion.identity);
                if (Input.GetKey(KeyCode.P))
                {
                    _Bullet.transform.localScale = new Vector3(6, 6, 1);
                }
                
                Rigidbody2D bulletbody = _Bullet.GetComponent<Rigidbody2D>();
                bulletbody.velocity = ShootLine.normalized * speed;
                timer = 0;
            } 
        }
    }
}
