using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        //Moves the bullet forward
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
