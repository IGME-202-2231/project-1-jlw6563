using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollisoinManager : MonoBehaviour
{
    

    [SerializeField]
    PlayerShooting playerShootScript;

    [SerializeField]
    EnemySpawner enemySpawnerScript;

    [SerializeField]
    SpriteVal playerSprite;

    [SerializeField]
    Text text;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject health1;
    [SerializeField]
    GameObject health2;
    [SerializeField]
    GameObject health3;

    int playerLives = 3;
    float invinsibilityTimer = 0;

    int score = 0;

    /// <summary>
    /// Gets and sets player lives
    /// </summary>
    public int PlayerLives
    {
        get { return playerLives; }
        set { playerLives = value; }
    }

    /// <summary>
    /// Gets and sets the score
    /// </summary>
    public int Score
    {
        get
        {return score;}
        set { score = value; }
    }
    
    // Update is called once per frame
    void Update()
    {
        //Goes through each bullet in the list
        for (int i = 0; i < playerShootScript.Bullets.Count; i++)
        {
            //Goes through each enemy in the list
            for (int j = 0; j < enemySpawnerScript.Enemies.Count; j++)
            {
                //Makes sure the bullets didn't get deleted and that there aren't 0 bullets
                if (playerShootScript.Bullets.Count != 0 && enemySpawnerScript.Enemies.Count != 0)
                {
                    //Creates enemy and bullet SpriteVal which hold colision box info
                    SpriteVal enemy = enemySpawnerScript.Enemies[j].GetComponent<SpriteVal>();
                    SpriteVal bullet = playerShootScript.Bullets[i].GetComponent<SpriteVal>();

                    //Checks if those boxes are colliding with each other
                    if (AABBCheck(bullet, enemy))
                    {
                        //Creates 2 temp gameobjects that are both the colliding objects
                        GameObject tempBull = playerShootScript.Bullets[i];
                        GameObject tempEn = enemySpawnerScript.Enemies[j];

                        //For scoreing gets the enemies type and if its the shooting enemy gives 300 points instead of 100
                        if(tempEn.GetComponent<Enemy>().IsType2 == true)
                        {
                            score += 300;
                        }
                        else
                        {
                            score += 100;
                        }
                        enemySpawnerScript.Enemies.RemoveAt(j);
                        playerShootScript.Bullets.RemoveAt(i);
                        Destroy(tempEn);
                        Destroy(tempBull); 
                    }
                }
            }
        }
        // player enemyBullet Collision

        //Goes through each enemy bullet in the list
        for (int i = 0; i < enemySpawnerScript.Bullets.Count; i++)
        {
            //Makes sure the bullets didn't get deleted and that there aren't 0 bullets
            if (enemySpawnerScript.Bullets.Count != 0 )
            {
                SpriteVal bullet = enemySpawnerScript.Bullets[i].GetComponent<SpriteVal>();

                //Checks if those boxes are colliding with each other
                if (AABBCheck(bullet, playerSprite))
                {
                    //Creates 1 temp gameobjects that are both the colliding objects
                    GameObject tempBull = enemySpawnerScript.Bullets[i];
                    //destroys the bullet, removes from list increses count of list, makes player invinsible and deletes a life
                    enemySpawnerScript.Bullets.RemoveAt(i);
                    Destroy(tempBull);
                    i++;
                    playerLives--;
                    playerInvibile();
                }
            }
         
        }
        //Updates text score
        text.text = score.ToString();

        //If invinsiblity has run out and player lives is greater than 0 set player active
        if(invinsibilityTimer < 0 && playerLives > 0)
        {
            player.SetActive(true);
        }
        //Otherwise decrease the time
        else
        {
            invinsibilityTimer -= 1 * Time.deltaTime;
        }
        //For setting the images of player lives to active
        if(playerLives < 3)
        {
            health3.SetActive(false);
        }
        if(playerLives < 2) {
            health2.SetActive(false);
        }
        if(playerLives < 1)
        {
            health1.SetActive(false);
        }
        //If player health is equal to 3
        if(playerLives == 3)
        {
            health3.SetActive(true);
            health2.SetActive(true);
            health1.SetActive(true);
        }
    }

    /// <summary>
    /// Checks collisoins
    /// </summary>
    /// <param name="spriteA">First box to check</param>
    /// <param name="spriteB">Second box to check</param>
    /// <returns></returns>
    bool AABBCheck(SpriteVal spriteA, SpriteVal spriteB)
    {
        return spriteB.RectMin.x < spriteA.RectMax.x && spriteB.RectMax.x > spriteA.RectMin.x && spriteB.RectMax.y > spriteA.RectMin.y && spriteB.RectMin.y < spriteA.RectMax.y;
    }

    public void playerInvibile()
    {
        player.SetActive(false);
        invinsibilityTimer = 1.5f;

    }
}
