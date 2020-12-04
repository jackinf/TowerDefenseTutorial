using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    public int health = 100;

    public int priceValue = 50;

    public GameObject deathEffect;

    private Transform target;
    private int waypointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            health = 0;
            Die();
        }
    }

    private void Die()
    {
        Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity), 5f);
        
        PlayerStats.Money += priceValue;
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        var direction = target.position - transform.position;
        transform.Translate(direction.normalized * (speed * Time.fixedDeltaTime));

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
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
