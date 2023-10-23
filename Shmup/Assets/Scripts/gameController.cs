using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    //For the 2 different states the game is in
    public enum GameStates
    {
        play,
        Gameover,
    }

    [SerializeField]
    CollisoinManager collisoinManagerScript;

    [SerializeField]
    EnemySpawner enemySpawnerScript;

    [SerializeField]
    GameObject enemySpawner;

    [SerializeField]
    GameObject gameOverUI;

    [SerializeField]
    GameObject player;

    //Holds the game state
    public GameStates gameState;
    //Int holds the highscore
    int highScore = 0;

    [SerializeField]
    Text gameOverText;

    // Update is called once per frame
    void Update()
    {
        //When the game state is game over
        if(gameState == GameStates.Gameover)
        {
            //Sets the UI active, turns off spawning, and the player
            gameOverUI.SetActive(true);
            enemySpawner.SetActive(false);
            player.SetActive(false);

            //Checks if highscore should be updated
            if (highScore < collisoinManagerScript.Score)
            {
                highScore = collisoinManagerScript.Score;
            }

            //Resets the text.
            gameOverText.text = "Game Over\nPress 'R' to reset\nHigh Score: " + highScore;

            //To restart the game
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Sets the game state to plat  Sets UI off then activates the spawner and player and lives
                gameState = GameStates.play;
                gameOverUI.SetActive(false);
                enemySpawner.SetActive(true);
                player.SetActive(true);
                collisoinManagerScript.PlayerLives = 3;
                
                //Loops thru deletes all enemies
                for(int i = 0; i < enemySpawnerScript.Enemies.Count; i++)
                {
                    Destroy(enemySpawnerScript.Enemies[i].gameObject);
                }
                //Clears the list and spawns in new enemies and resets score
                enemySpawnerScript.Enemies.Clear();
                enemySpawnerScript.Spawn();
                collisoinManagerScript.Score = 0;
            }
        }
        //If player runs outta lives game is over
        if(collisoinManagerScript.PlayerLives == 0)
        {
            gameState = GameStates.Gameover;
        }

        //For every enemy 
        for(int i = 0; i < enemySpawnerScript.Enemies.Count; i++)
        {
            //If one of the enemies gets to the same level as the player game is over.
            if (enemySpawnerScript.Enemies[i].transform.position.y == -4)
            {
                gameState = GameStates.Gameover;
            }
        }
    }
}
