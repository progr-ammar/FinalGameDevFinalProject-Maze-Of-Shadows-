using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    // Public property to access the GameManager instance
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("GameManager instance is null! Ensure a GameManager is in the scene.");
            }
            return instance;
        }
    }

    public static string currentLevel = "MainMenu"; // Default level name

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    public static void SetCurrentLevel(string levelName)
    {
        currentLevel = levelName;
    }

    public static string GetCurrentLevel()
    {
        return currentLevel;
    }

    public void RestartLevel()
    {
        if (!string.IsNullOrEmpty(currentLevel))
        {
            SceneManager.LoadScene(currentLevel);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}


