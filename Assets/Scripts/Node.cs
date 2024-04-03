using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffSet;

    public Color noMoneyColer; 

    [Header("Optional")]

    BuildManager buildManager;
    
    public GameObject turret;

    private Renderer rend;

    private Color startColor;


    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseEnter()
    {

        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(!buildManager.CanBuild)
        {
            return;
        }
        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = noMoneyColer;
        }

        
    }

    void OnMouseDown()
    {

        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(!buildManager.CanBuild)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO : Display on screen");
            return;
        }

        buildManager.BuildTurretOn(this);

    }

    public Vector3 GetBuildPosition()
    {
       return transform.position + positionOffSet;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
