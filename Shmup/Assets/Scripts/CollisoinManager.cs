using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisoinManager : MonoBehaviour
{
    [SerializeField]
    PlayerShooting playerShootScript;

    [SerializeField]
    EnemySpawner enemySpawnerScript;

    [SerializeField]
    SpriteVal playerSprite;

    

    
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
                        enemySpawnerScript.Enemies.RemoveAt(j);
                        playerShootScript.Bullets.RemoveAt(i);
                        Destroy(tempEn);
                        Destroy(tempBull);
                        
                    }
                }
            }
        }
        /* player enemyBullet Collision

        for (int j = 0; j < enemySpawnerScript.Enemies.Count; j++)
        {
            if (enemySpawnerScript.Enemies[j].GetComponent<Enemy>().IsType2 == true)
            {
                EnemyShoot enemyShootingScript = enemySpawnerScript.Enemies[j].GetComponent<EnemyShoot>();
                for (int i = 0; i < enemyShootingScript.Bullets.Count; i++)
                {
                    if (enemyShootingScript.Bullets.Count != 0)
                    {
                        SpriteVal enemyBullet = enemyShootingScript.Bullets[i].GetComponent<SpriteVal>();
                        if (AABBCheck(playerSprite, enemyBullet))
                        {
                            //Creates 2 temp gameobjects that are both the colliding objects
                            GameObject tempBull = enemyShootingScript.Bullets[i];
                            enemyShootingScript.Bullets.RemoveAt(i);
                            Destroy(tempBull);
                        }
                    }
                }
            }
        }
        */
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
}
