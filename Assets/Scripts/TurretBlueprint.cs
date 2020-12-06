using System;
using UnityEngine;

[Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;
    public int sellCost;

    public int GetSellAmount()
    {
        return sellCost;
    }
}
