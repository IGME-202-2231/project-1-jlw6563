using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Enemy gameobject, timer, list of enemies, bool for is waiting
    [SerializeField]
    List<GameObject> enemyArt;
    float timer = 0;
    List<GameObject> enemies = new List<GameObject>();
    bool isWaiting = false;

    /// <summary>
    /// Get and set for enemies list
    /// </summary>
    public List<GameObject> Enemies
    {
        get
        {
            return enemies;
        }
        set
        {
            enemies = value;
        }
    }

    //On Start calls spawn once
    public void Start()
    {
        Spawn();
    }

    public void Update()
    { 
        //CHecks if isWaiting is false
        if(isWaiting == false)
        {
            //If yes resets the timer
            TimerReset();
        }

        //Makes timer go down
        timer -= 1 * Time.deltaTime;
        
        //If we are waiting and timer is less than 0 then call spawn.
        if(isWaiting == true && timer < 0)
        {
            Spawn();
        }
       
    }

    /// <summary>
    /// Spawns new enemies
    /// </summary>
    public void Spawn()
    {
        //Sets is waiting to false
        isWaiting = false;
        //Loops through all the old enemies and pushes them down
        for (int i = 0; i < enemies.Count; i++) { 
            //Creates the new y value
            float newY = enemies[i].transform.position.y - 2;
            //Sets everyhing equal to the same except the new y
            enemies[i].transform.position = new Vector3(enemies[i].transform.position.x, newY, enemies[i].transform.position.z);
        }
        //Sets the starting x
        int x = -8;
        //Loops through 11 times
        for (int i = 0; i < 9; i++)
        {
            int type = Random.Range(0, 2);
            //Creates an enemy at same y and sets the X to int x  and then adds 2 to the x val for the offset
            enemies.Add(Instantiate(enemyArt[type], new Vector3(x, 4, 0), transform.rotation));

            //For player bullet collision sets the enemies i to a certain type
            if (type == 0)
            {
                enemies[i].GetComponent<Enemy>().IsType2 = false;
            }
            else
            {
                enemies[i].GetComponent<Enemy>().IsType2 = true;
            }
            x += 2;
        }
    }

    /// <summary>
    /// Resets the timer
    /// </summary>
    public void TimerReset()
    {
        //Sets isWaiting to true and timer to 10
        isWaiting= true;
        timer = 10;
    }
}
