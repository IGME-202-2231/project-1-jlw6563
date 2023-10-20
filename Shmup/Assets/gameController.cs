using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState == GameStates.Gameover)
        {
            gameOverUI.SetActive(true);
            enemySpawner.SetActive(false);
            player.SetActive(false);

            
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
