using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel(string MainMenu)
    {
        SceneManager.LoadScene("MainMenu");
    }
}

