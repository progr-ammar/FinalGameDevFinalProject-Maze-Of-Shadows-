using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class HardScript : MonoBehaviour
{
    public Transform player; // Assign the player's Transform in the Inspector
    public float winZPosition = 93f; // Z-position for winning
    public float loseZPosition = -93f; // Z-position for losing

    public Text scoreText; // Assign a UI Text object in the Inspector
    private int score = 0; // Initial score

    [SerializeField] private string gameOverHard = "GameOverEH"; // Scene name for Game Over
    public string winScreenHard = "YouWonEH";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(gameOverHard);
        }
    }

    void Start()
    {
        // Set the current level name in the GameManager
        GameManager.SetCurrentLevel("Hard");
    }

    void Update()
    {
        if (player != null)
        {
            // Check if the player has won
            if (player.position.z >= winZPosition)
            {
                LoadScene("YouWonEH"); // Replace with your win scene name
            }

            // Check if the player has lost
            if (player.position.z <= loseZPosition)
            {
                LoadScene("GameOverEH"); // Replace with your lose scene name
            }
        }
        // Check if no coins are left in the scene
        if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
        {
            SceneManager.LoadScene(winScreenHard);
        }
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with has the tag "Coin"
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject); // Destroy the coin
            IncreaseScore(); // Increment the score
        }
    }

    void IncreaseScore()
    {
        score += 1; // Increase the score by 1
        UpdateScoreUI(); // Update the score display
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString(); // Update the UI text
    }
}
