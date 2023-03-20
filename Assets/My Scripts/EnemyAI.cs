using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // The speed at which the enemy moves
    public float moveSpeed = 3f;

    // The amount of health the enemy has
    public float health = 100f;

    // The amount of damage the enemy does to the player
    public float damage = 10f;

    // The current waypoint that the enemy is moving towards
    private GameObject targetWaypoint;

    private void Start()
    {
        // Get the first waypoint from the WaypointManager
        targetWaypoint = WaypointManager.Instance.GetWaypoint(0);
    }

    private void Update()
    {
        // If there is no targetWaypoint, do nothing
        if (targetWaypoint == null)
        {
            return;
        }

        // Calculate the direction towards the target waypoint
        Vector3 direction = targetWaypoint.transform.position - transform.position;

        // Move towards the target waypoint
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

        // If the enemy has reached the target waypoint, get the next one
        if (Vector3.Distance(transform.position, targetWaypoint.transform.position) < 0.1f)
        {
            targetWaypoint = targetWaypoint.GetComponent<Waypoint>().NextWaypoint.gameObject;

        }
    }

    // Called when the enemy takes damage
    public void TakeDamage(float amount)
    {
        health -= amount;

        // If the enemy's health is zero or less, destroy it
        if (health <= 0)
        {
            Die();
        }
    }

    // Called when the enemy dies
    private void Die()
    {
        Destroy(gameObject);
    }

    // Called when the enemy collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        // If the enemy collides with the player, damage the player and destroy the enemy
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Die();
        }
    }
}

