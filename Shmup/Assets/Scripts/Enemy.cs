using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //to get the enemies render
    [SerializeField]
    SpriteRenderer enemieRender;
    //For bullet collision with player
    bool isType2;

    //Get and set for type
    public bool IsType2
    {
        get { return isType2; }
        set { isType2 = value; }
    }
}
