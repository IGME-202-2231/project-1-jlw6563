using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    //Gets the bullet Prefab
    [SerializeField]
    GameObject bullet;

    List<GameObject> bullets = new List<GameObject>();

    public List<GameObject> Bullets
    {
        get { return bullets; }
        set { bullets = value; }
    }


    // Update is called once per frame
    void Update()
    {
        //When the space key is pressed NOT held down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Creates a bullet by instatiating it.
            bullets.Add(Instantiate(bullet, transform.position,transform.rotation));
        }
        
        //For every bullet if it goes off screen it is removed and the list is counter is subtracted by 1
        for (int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i].transform.position.y > 6)
            {
                Destroy(bullets[i]);
                bullets.Remove(bullets[i]);
                i++;
            }
        }
    }
}
