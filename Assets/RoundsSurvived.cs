using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    public Text roundsText;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    private IEnumerator AnimateText()
    {
        roundsText.text = "0";
        var round = 0;

        yield return new WaitForSeconds(.7f); // small lag to wait for all animations etc
        
        while (round < PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }
}
