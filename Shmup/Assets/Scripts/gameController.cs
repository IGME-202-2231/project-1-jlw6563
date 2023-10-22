using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
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

    public GameStates gameState;
    int highScore = 0;

    [SerializeField]
    Text gameOverText;

    // Update is called once per frame
    void Update()
    {
        if(gameState == GameStates.Gameover)
        {
            gameOverUI.SetActive(true);
            enemySpawner.SetActive(false);
            player.SetActive(false);

            if (highScore < collisoinManagerScript.Score)
            {
                highScore = collisoinManagerScript.Score;
            }

            gameOverText.text = "Game Over\nPress 'R' to reset\nHigh Score: " + highScore;

            if (Input.GetKeyDown(KeyCode.R))
            {
                gameState = GameStates.play;
                gameOverUI.SetActive(false);
                enemySpawner.SetActive(true);
                player.SetActive(true);
                collisoinManagerScript.PlayerLives = 3;
                
                for(int i = 0; i < enemySpawnerScript.Enemies.Count; i++)
                {
                    Destroy(enemySpawnerScript.Enemies[i].gameObject);
                }
                enemySpawnerScript.Enemies.Clear();
                enemySpawnerScript.Spawn();
                collisoinManagerScript.Score = 0;
            }
        }
        if(collisoinManagerScript.PlayerLives == 0)
        {
            gameState = GameStates.Gameover;
        }

        for(int i = 0; i < enemySpawnerScript.Enemies.Count; i++)
        {
            if (enemySpawnerScript.Enemies[i].transform.position.y == -4)
            {
                gameState = GameStates.Gameover;
            }
        }
    }
}
