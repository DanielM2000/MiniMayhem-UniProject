// EnemySpawner.cs
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WaveConfig
{
    [Space(50)]
    public float delayBeforeStarting;
    public int numberOfEnemies;
    public GameObject[] enemyPrefabs;
    public LineRenderer path;
}

public class EnemySpawner : MonoBehaviour
{
    
    
    public List<WaveConfig> waveConfigs;
    [Space(200)]
    public float spawnInterval = 1.0f;
    public float timeBetweenWaves = 10.0f;

    public Text enemiesRemainingText;

    private int currentWave = 0;
    private int enemiesRemaining;
    private bool isSpawning = true;
    private bool waitingForNextWave = false;
    private bool gameStarted = false;

    public Transform target;
    

    void Start()
    {
        enemiesRemainingText.text = "Enemies Remaining: " + enemiesRemaining.ToString();
    }

    void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.E))
        {
            gameStarted = true;
            StartNextWave();
        }
        else if (waitingForNextWave && Input.GetKeyDown(KeyCode.E))
        {
            // Start the next wave
            currentWave++;
            if (currentWave < waveConfigs.Count)
            {
                isSpawning = true;
                waitingForNextWave = false;
                InvokeRepeating("SpawnEnemy", waveConfigs[currentWave].delayBeforeStarting, spawnInterval);
                enemiesRemaining = waveConfigs[currentWave].numberOfEnemies;
                enemiesRemainingText.text = "Enemies Remaining: " + enemiesRemaining.ToString();
            }
        }
    }

    public void SpawnEnemy()
    {
        if (enemiesRemaining > 0 && isSpawning)
        {
            // Instantiate the enemy prefab at the spawner's position
            GameObject[] currentWavePrefabs = waveConfigs[currentWave].enemyPrefabs;
            GameObject enemyPrefab = currentWavePrefabs[Random.Range(0, currentWavePrefabs.Length)];
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // Set the path for the enemy to follow
            EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
            enemyAI.SetPath(waveConfigs[currentWave].path);
            enemyAI.target = target;

            // Set the enemy's initial position to the first point on the path
            enemy.transform.position = waveConfigs[currentWave].path.GetPosition(0);

            enemiesRemaining--;
            enemiesRemainingText.text = "Enemies Remaining: " + enemiesRemaining.ToString();
        }
        else if (enemiesRemaining <= 0 && isSpawning && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            isSpawning = false;
            waitingForNextWave = true;
            CancelInvoke("SpawnEnemy");
        }
    }

    void StartNextWave()
    {
        if (currentWave < waveConfigs.Count)
        {
            // Start the next wave
            isSpawning = true;
            waitingForNextWave = false;
            InvokeRepeating("SpawnEnemy", waveConfigs[currentWave].delayBeforeStarting, spawnInterval);
            enemiesRemaining = waveConfigs[currentWave].numberOfEnemies;
            enemiesRemainingText.text = "Enemies Remaining: " + enemiesRemaining.ToString();
        }
        else
        {
            // All waves are complete
            CancelInvoke("SpawnEnemy");
        }
    }



    void OnGUI()
    {
        if (!gameStarted)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Press E to Start");
        }
        else if (waitingForNextWave)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 25, 150, 50), "Press E to Start Next Wave");
        }
        int enemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // Display the remaining number of enemies
        enemiesRemainingText.text = "Enemies Remaining: " + enemiesRemaining.ToString();
    }
}