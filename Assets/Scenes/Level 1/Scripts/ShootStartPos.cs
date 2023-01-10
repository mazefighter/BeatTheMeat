using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootStartPos : MonoBehaviour
{
    [SerializeField] private GameObject mousePos;
    private Vector3 distancePlayerMouse;
    [SerializeField]private GameObject Player;
    public float Xpos;
    public float Ypos;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        distancePlayerMouse = new Vector3(mousePos.transform.position.x - transform.position.x,mousePos.transform.position.y - transform.position.y,0);
        if (distancePlayerMouse.x < 0)
        {
            transform.position = new Vector2(-Xpos , Ypos);
        }
        if (distancePlayerMouse.x > 0)
        {
            transform.position = new Vector2(Xpos , Ypos);
        }
        
    }
}
