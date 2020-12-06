using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int waypointIndex = 0;
    private Enemy enemy;
    
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
    }
    
    private void Update()
    {
        var direction = target.position - transform.position;
        transform.Translate(direction.normalized * (enemy.speed * Time.deltaTime));

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    private void GetNextWaypoint()
    {
        waypointIndex++;
        if (Waypoints.points.Length <= waypointIndex)
        {
            EndPath();
            return;
        }
        target = Waypoints.points[waypointIndex];
    }

    private void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
