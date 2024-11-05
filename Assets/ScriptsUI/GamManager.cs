using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamManager : MonoBehaviour
{
    [SerializeField] GameOverUI gameOverUI;
    EnemySpawner enemySpawner;

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        PauseGame();
        enemySpawner.enabled = false;
        gameOverUI.gameObject.SetActive(true);
    }
}
