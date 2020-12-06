using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public const string LevelReachedKey = "LevelReached";
    
    public SceneFader sceneFader;

    public Button[] levelButtons;

    private void Start()
    {
        var levelReached = PlayerPrefs.GetInt(LevelReachedKey, 1);

        for (var index = 0; index < levelButtons.Length; index++)
        {
            if (index + 1 > levelReached)
                levelButtons[index].interactable = false;
        }
    }

    public void Select(string levelName)
    {
        sceneFader.FadeTo(levelName);
    }
}
