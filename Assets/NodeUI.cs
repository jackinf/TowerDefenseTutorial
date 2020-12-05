using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public Text upgradeCost;
    public Text sellCost;
    private Node target;
    public Button upgradeButton;

    public void SetTarget(Node target)
    {
        this.target = target;

        transform.position = target.GetBuildPosition();

        sellCost.text = "$" + target.turretBlueprint.sellCost;

        if (target.isUpgraded)
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        else
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        
    }
}
