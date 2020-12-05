using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector] public GameObject turret;
    [HideInInspector] public TurretBlueprint turretBlueprint;
    [HideInInspector] public bool isUpgraded = false;
    
    private Renderer rend;
    private Color startColor;

    private BuildManager buildmanager;
    
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        
        buildmanager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition() => transform.position + positionOffset;

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (turret != null)
        {
            buildmanager.SelectNode(this);
            return;
        }
        
        if (!buildmanager.CanBuild)
        {
            return;
        }

        BuildTurret(buildmanager.GetTurretToBuild());
    }

    private void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        
        turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);

        turretBlueprint = blueprint;

        var effect = Instantiate(buildmanager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        // Get rid of the old turret
        Destroy(turret);
        
        // Build a new one
        turret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);

        Destroy(Instantiate(buildmanager.buildEffect, GetBuildPosition(), Quaternion.identity), 5f);

        isUpgraded = true;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (!buildmanager.CanBuild)
        {
            return;
        }

        if (buildmanager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
