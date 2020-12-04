using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text moneyText;

    void Update()
    {
        moneyText.text = $"${PlayerStats.Money}";
    }
}
