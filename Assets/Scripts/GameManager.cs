﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;

    private void Start()
    {
        GameIsOver = false;
    }
    
    private void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
}