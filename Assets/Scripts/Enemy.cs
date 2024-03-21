using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = WayPoint.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); 

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypooint();
        }   
    }

    void GetNextWaypooint()
    {

        if(wavepointIndex >= WayPoint.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = WayPoint.points[wavepointIndex];
    }
}
