using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Transform spawnPoint;
    public GameObject deathCamera;
    public Camera Player;
    private bool playerIsDead = false;
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
        void OnTriggerEnter(Collider other)
         {
        Debug.Log("take damage");
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(other.gameObject.GetComponent<EnemyAI>().damage);
            
        }
         }

    private void Die()
    {
        playerIsDead = true;

        // Switch to death camera
        Camera.main.gameObject.SetActive(false);
        deathCamera.SetActive(true);

        // Disable player control
        GetComponent<FirstPersonController>().enabled = false;

        // Respawn player after 10 seconds
        StartCoroutine(RespawnAfterDelay(10f));
    }

    private IEnumerator RespawnAfterDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);

        // Reset player position and health
        transform.position = spawnPoint.position;
        currentHealth = maxHealth;

        // Enable player control
        GetComponent<FirstPersonController>().enabled = true;

        // Switch back to main camera
        deathCamera.SetActive(false);
        Camera.main.gameObject.SetActive(true);

        playerIsDead = false;
    }
    


    private void Update()
    {
        if (!playerIsDead)
        {
            // Handle player movement and shooting
        }
        else
        {
            // Player is dead, disable movement and shooting
        }
    }
}
