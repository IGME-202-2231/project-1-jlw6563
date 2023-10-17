using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // === Feilds ===

    [SerializeField]
    SpriteVal spriteVal;
    float speed = 15f;


    // Update is called once per frame
    void Update()
    {
        //If the A key is being pressed
        if (Input.GetKey(KeyCode.A))
        {
            //Increases the position by -1 times the speed to make the ship go left
            transform.position += Vector3.left * speed * Time.deltaTime ;
        }

        //If the D key is being pressed
        if (Input.GetKey(KeyCode.D))
        {
            //Increases the position by +1 times the speed to make the ship go left
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if(transform.position.x > 11)
        {
            transform.position = new Vector3(8, transform.position.y, 0);
        }
        if (transform.position.x < -8)
        {
            transform.position = new Vector3(-8, transform.position.y, 0);
        }
    }
}
