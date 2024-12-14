using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class BonusScript : MonoBehaviour
{
    public Transform player; // Assign the player's Transform in the Inspector
    public float winZPosition = 82f; // The z-value for winning
    public float loseZPosition = -88f; // The z-value for losing

    public Text scoreText; // Assign a UI Text object in the Inspector
    private int score = 0; // Score starts at 0

    [SerializeField] private string gameOverBonus = "GameOver"; // Scene name for Game Over
    public string winScreenBonus = "YouWon";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(gameOverBonus);
        }
    }

    void Start()
    {
        // Set the current level name in the GameManager
        //GameManager.SetCurrentLevel("Bonus");
    }

    void Update()
    {
        if (player != null)
        {
            // Check if the player has won
            if (player.position.z >= winZPosition)
            {
                LoadScene("YouWon"); // Replace "YouWon" with your win scene name
            }

            // Check if the player has lost
            if (player.position.z <= loseZPosition)
            {
                LoadScene("GameOver"); // Replace "GameOver" with your lose scene name
            }
        }
        // Check if no coins are left in the scene
        if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
        {
            SceneManager.LoadScene(winScreenBonus);
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