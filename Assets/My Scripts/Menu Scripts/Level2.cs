using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    public void LoadLevel(string Bedroom)
    {
        SceneManager.LoadScene("Bedroom");
    }
}

