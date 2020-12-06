using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;
    public SceneFader sceneFader;

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

    public void WinLevel()
    {
        Debug.Log("LEVEL WON!");
        PlayerPrefs.SetInt(LevelSelector.LevelReachedKey, levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }
}
