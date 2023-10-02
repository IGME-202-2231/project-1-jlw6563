using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // === Feilds ===

    
    float speed = 20f;


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
    }
}
