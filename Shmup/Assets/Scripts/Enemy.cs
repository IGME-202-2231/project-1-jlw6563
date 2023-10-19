using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    //to get the enemies render
    [SerializeField]
    SpriteRenderer enemieRender;
    //For bullet collision with player
    bool isType2;
    float orignialX;
    float speed = .3f;

    private void Start()
    {
        orignialX = transform.position.x;
    }

    private void Update()
    {
        if(transform.position.x > orignialX + 2)
        {
            speed *= -1;
        }
        if (transform.position.x < orignialX - 2)
        {
            speed *= -1;
        }

        transform.position += Vector3.left * speed * Time.deltaTime; 
    }

    //Get and set for type
    public bool IsType2
    {
        get { return isType2; }
        set { isType2 = value; }
    }
}
