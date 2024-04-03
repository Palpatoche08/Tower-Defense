using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBluePrint standardTurret;
    public TurretBluePrint missileLauncher;
    public TurretBluePrint laserBeamer;


    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret()
    {
        Debug.Log("Standart Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("LaserBeamer Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
    
}
