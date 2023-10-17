using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        //Moves the bullet Down
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
