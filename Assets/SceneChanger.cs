using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void goToStory()
    {
        SceneManager.LoadScene("Story");
    }
    public void goToInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void goToLevels()
    {
        SceneManager.LoadScene("Levels");
    }
    //public void goToEasyLevel()
    //{
    //    SceneManager.LoadScene("Easy");
    //}
    //public void goToHardLevel()
    //{
    //    SceneManager.LoadScene("Hard");
    //}
    public void goToBonusLevel()
    {
        SceneManager.LoadScene("Bonus");
    }
    public void GoToEasyLevel()
    {
        GameManager.SetCurrentLevel("Easy");
        SceneManager.LoadScene("Easy");
    }

    public void GoToHardLevel()
    {
        GameManager.SetCurrentLevel("Hard");
        SceneManager.LoadScene("Hard");
    }

    //public void GoToBonusLevel()
    //{
    //    GameManager.SetCurrentLevel("Bonus");
    //    SceneManager.LoadScene("Bonus");
    //}
    public void RetryLevel()
    {
        GameManager.Instance.RestartLevel();
    }
    public void QuitGame()
    {
        // Close the application
        Application.Quit();

        // For testing in the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public Button pauseButton; // Reference to the pause button
    public GameObject pauseMenu; // Optional: Assign a pause menu UI panel if you have one

    private bool isPaused = false;

    void Start()
    {
        // Ensure the game is unpaused initially
        Time.timeScale = 1f;

        // Add a listener to the button
        pauseButton.onClick.AddListener(TogglePause);
    }
    void Update()
    {
        // Toggle Pause Menu when the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Freeze the game
            if (pauseMenu != null) pauseMenu.SetActive(true); // Show pause menu if assigned
        }
        else
        {
            Time.timeScale = 1f; // Resume the game
            if (pauseMenu != null) pauseMenu.SetActive(false); // Hide pause menu if assigned
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false); // Hide Pause Menu
        Time.timeScale = 1f; // Resume game time
        isPaused = false; // Update pause state
        //Cursor.lockState = CursorLockMode.Locked; // Lock cursor
        //Cursor.visible = false; // Hide cursor
    }

    private void Pause()
    {
        pauseMenu.SetActive(true); // Show Pause Menu
        Time.timeScale = 0f; // Freeze game time
        isPaused = true; // Update pause state
        Cursor.lockState = CursorLockMode.None; // Unlock cursor
        Cursor.visible = true; // Show cursor
    }

}