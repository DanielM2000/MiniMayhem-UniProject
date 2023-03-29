using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // The speed at which the enemy moves
    public float moveSpeed = 3f;

    // The amount of health the enemy has at the start of the game.
    public float startingHealth = 100f;
    // The amount of health the enemy has at the current time.
    public float currentHealth;

    public GameObject deathEffect;

    // The amount of damage the enemy does to the player and base.
    public float damage = 10f;

    public Transform target;

    public LineRenderer path;

    private int currentPathIndex = 0;

    private Collider enemyCollider;

    public float detectionRange = 5f;


    private void Start()
    {
        currentHealth = startingHealth;
        enemyCollider = GetComponent<Collider>();
        enemyCollider.isTrigger = false;
    }

    public void Update()
    {
        // If we've reached the end of the path, destroy the enemy
        if (currentPathIndex >= path.positionCount)
        {
            Destroy(gameObject);
            return;
        }

        // Move the enemy towards the current point on the path
        transform.position = Vector3.MoveTowards(transform.position, path.GetPosition(currentPathIndex), moveSpeed * Time.deltaTime);

        // If we've reached the current point on the path, move to the next point
        if (Vector3.Distance(transform.position, path.GetPosition(currentPathIndex)) < 0.1f)
        {
            currentPathIndex++;
        }
        if (Vector3.Distance(transform.position, target.position) <= detectionRange)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            // Follow the path
            transform.position = Vector3.MoveTowards(transform.position, path.GetPosition(currentPathIndex), moveSpeed * Time.deltaTime);

            // If we've reached the current point on the path, move to the next point
            if (Vector3.Distance(transform.position, path.GetPosition(currentPathIndex)) < 0.1f)
            {
                currentPathIndex++;
            }
        }

    }

    // Called when the enemy takes damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Called when the enemy dies
    void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }

    // Called when the enemy collides with another object
    
   

    // Sets the path that the enemy will follow
    public void SetPath(LineRenderer lineRenderer)
    {
        path = lineRenderer;
        currentPathIndex = 0;
    }
}
