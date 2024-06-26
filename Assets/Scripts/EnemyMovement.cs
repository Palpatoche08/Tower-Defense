using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{

    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

    void Start()
    {

        enemy = GetComponent<Enemy>();
        target = WayPoint.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World); 

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypooint();
        }   

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypooint()
    {

        if(wavepointIndex >= WayPoint.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = WayPoint.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
