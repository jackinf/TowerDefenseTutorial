﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded;
    
    private void Update()
    {
        if (gameEnded)
        {
            return;
        }
        
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over!");
        
    }
}
