using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    //Bullet 
    [SerializeField]
    GameObject bullet;
    float timer = 0;
    bool isWaiting = false;

    List<GameObject> bullets = new List<GameObject>();

    public List<GameObject> Bullets
    {
        get { return bullets; }
        set { bullets = value; }
    }


    // Update is called once per frame
    void Update()
    {
        //CHecks if isWaiting is false
        if (isWaiting == false)
        {
            //If yes resets the timer
            TimerReset();
        }

        //Makes timer go down
        timer -= 1 * Time.deltaTime;

        //If we are waiting and the tinmer is less than true
        if (isWaiting == true && timer < 0)
        {
            //Is waiting is false
            isWaiting = false;
            //Creates a bullet by instatiating it.
            bullets.Add(Instantiate(bullet, transform.position, transform.rotation));
        }
        

        //For every bullet if it goes off screen it is removed and the list is counter is subtracted by 1
        for (int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i].transform.position.y < -6)
            {
                Destroy(bullets[i]);
                bullets.Remove(bullets[i]);
                i--;
            }
        }


    }

    /// <summary>
    /// Resets the timer
    /// </summary>
    public void TimerReset()
    {
        //Sets isWaiting to true and timer to 10
        isWaiting = true;
        timer = Random.Range(2,15);
    }
}
