using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    

    public static GameManager Instance { get; private set; }

    // The game over screen object
    public Canvas canvas;
    internal static object instance;

    private void Awake()
    {
        // Set the Instance variable to this object
        Instance = this;
    }

    // The GameOver method to be called when the game is over
    public void GameOver()
    {
        canvas.enabled = true;
        Time.timeScale = 0f;
    }
    public void ResetTimeScale()
    {
        Time.timeScale = 1f;
    }
}
