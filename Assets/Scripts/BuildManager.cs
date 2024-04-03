using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public TurretBluePrint turretToBuild;

    public static BuildManager instance;

    public GameObject buildEffect;



    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than 1 BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public bool CanBuild{ get { return turretToBuild != null; } }
    public bool HasMoney{ get { return PlayerStats.Money >= turretToBuild.cost;  } }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not Enough Money");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret build! Money Left: " + PlayerStats.Money);
    }



}
