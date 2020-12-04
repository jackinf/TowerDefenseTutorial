using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;

    void Start()
    {
        StartCoroutine(UpdateLiveText());
    }

    private IEnumerator UpdateLiveText()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            livesText.text = $"{PlayerStats.Lives} LIVES";
        }
    }
}
