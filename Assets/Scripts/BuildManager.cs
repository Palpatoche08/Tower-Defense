using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject turretToBuild;

    public static BuildManager instance;

    public GameObject standardTurretPrefab;



    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than 1 BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }


    // Update is called once per frame
    void Start ()
    {
        turretToBuild = standardTurretPrefab;
    }
}
