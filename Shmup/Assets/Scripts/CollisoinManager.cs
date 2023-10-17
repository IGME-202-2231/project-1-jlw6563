using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisoinManager : MonoBehaviour
{
    [SerializeField]
    PlayerShooting playerShootScript;

    [SerializeField]
    EnemySpawner enemySpawnerScript;

    

    
    // Update is called once per frame
    void Update()
    {
        //Goes through each bullet in the list
        for (int i = 0; i < playerShootScript.Bullets.Count; i++)
        {
            //Goes through each enemy in the list
            for (int j = 0; j < enemySpawnerScript.Enemies.Count; j++)
            {
                //Makes sure the bullets didn't get deleted
                if (playerShootScript.Bullets.Count != 0)
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
    }

    /// <summary>
    /// Checks collisoins
    /// </summary>
    /// <param name="spriteA">First box to check</param>
    /// <param name="spriteB">Second box to check</param>
    /// <returns></returns>
    bool AABBCheck(SpriteVal spriteA, SpriteVal spriteB)
    {
        
        return (spriteB.RectMin.x < spriteA.RectMax.x && spriteB.RectMax.x > spriteA.RectMin.x && spriteB.RectMax.y > spriteA.RectMin.y && spriteB.RectMin.y < spriteA.RectMax.y);
    }
}