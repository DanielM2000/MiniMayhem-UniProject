// EnemyCollisionCounter.cs
using UnityEngine;

public class EnemyCollisionCounter : MonoBehaviour
{
    public int maxCollisions = 10;
    private int currentCollisions = 0;

    public GameManager gameManager;

    public void IncrementCollisions()
    {
        currentCollisions++;

        if (currentCollisions >= maxCollisions)
        {
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }
}