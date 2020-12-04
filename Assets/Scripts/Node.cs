using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

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
        
        if (!buildmanager.CanBuild)
        {
            return;
        }
        
        if (turret != null)
        {
            Debug.Log("There's a turret already. TODO: display on screen");
            return;
        }

        buildmanager.BuildTurretOn(this);
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
