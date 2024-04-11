using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public TurretBluePrint turretToBuild;

    public Node selectedNode;
    public static BuildManager instance;

    public GameObject buildEffect;
    public GameObject sellEffect;

    public NodeUI nodeUI;



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
        DeselectNode();

    }

    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectNode(Node node)
    {

        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }





}
