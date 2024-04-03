using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform target;
    public Enemy targetEnemy;

    [Header("General")]

    public float range = 15f;

    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCoundown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;

    public int damageOverTime = 35;

    public float slowPct = .5f;
    public ParticleSystem impactEffect;
    public LineRenderer LineRenderer;
    
    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public Transform firePoint;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            

        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
}


    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            if(useLaser)
            {
                if(LineRenderer.enabled)
                {
                    LineRenderer.enabled = false;
                    impactEffect.Stop();

                }
            }
            return;
        }

        LockOnTarget();

        if(useLaser)
        {
            impactEffect.Play();
            Laser();
        }
        else
        {

            if( fireCoundown <= 0f)
            {
                Shoot();
                fireCoundown = 1f/ fireRate;

            }

            fireCoundown -= Time.deltaTime;
        }

    }

    void Laser()
    {

        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPct);
        if(!LineRenderer.enabled)
        {
            LineRenderer.enabled = true;
            impactEffect.Play();
        }
        LineRenderer.SetPosition(0, firePoint.position);
        LineRenderer.SetPosition(1, target.position);

        impactEffect.transform.position = target.position ; 
    }

    void LockOnTarget()
    {
        if(useLaser)
            {
                if(!LineRenderer.enabled)
                {
                    LineRenderer.enabled = true;
                }
            }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);

    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
