using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    //to get the enemies render
    [SerializeField]
    SpriteRenderer enemieRender;
    bool isType2;
    float orignialX;
    float speed = .3f;

    private void Start()
    {
        //Gets the original x for where it spawned
        orignialX = transform.position.x;
    }

    private void Update()
    {
        //If the position is more/less than 2 the orignial position it changes direction
        if(transform.position.x > orignialX + 2)
        {
            speed *= -1;
        }
        if (transform.position.x < orignialX - 2)
        {
            speed *= -1;
        }

        //Moves enemies
        transform.position += Vector3.left * speed * Time.deltaTime; 
    }

    //Get and set for type
    public bool IsType2
    {
        get { return isType2; }
        set { isType2 = value; }
    }
}
