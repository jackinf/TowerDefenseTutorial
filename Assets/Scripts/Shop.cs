using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Purchased");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
    
    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Purchased");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
