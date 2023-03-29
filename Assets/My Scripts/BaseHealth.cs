using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
            GameManager.Instance.GameOver(); // Call the GameOver method on the GameManager
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
}
       
