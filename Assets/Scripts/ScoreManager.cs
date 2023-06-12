using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highscoreText;

    public Image gameOverImage;

    public int score;
    int highscore;
    int scoreActiveIncrease = 10;

    float elapsedTime;
    float idleTimeTreshold = 1f;

    HungerMeter hungerMeter;
    PlayerHealth playerHealth;
    void Start()
    {
        hungerMeter = GetComponent<HungerMeter>();
        playerHealth = GetComponent<PlayerHealth>();

        gameOverImage.gameObject.SetActive(false);
        score = 0;
    }

    void Update()
    {
        if (score == 0)
        {
            Time.timeScale = 1f;
        }

        IdleScoreIncrease();
        UpdateScoreText();

        if (hungerMeter.currentHunger <= 0f)
        {
            gameOverImage.gameObject.SetActive(true);
            Time.timeScale = 0f;
            StarvedHighScore();
        }

        if (playerHealth.currentHealth <= 0)
        {
            gameOverImage.gameObject.SetActive(true);
            Time.timeScale = 0f;
            CaughtHighScore();
        }
    }

    private void IdleScoreIncrease()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime >= idleTimeTreshold)
        {
            score++;
            elapsedTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            score += scoreActiveIncrease;
        }
    }

    private void UpdateScoreText()
    {
        highscore = score;

        if (scoreText != null)
        {
            scoreText.text = "Score: " + highscore.ToString();
        }
    }

    private void StarvedHighScore()
    {
        if (highscoreText != null)
        {
            highscoreText.text = "GAME OVER! \nYou starved!\nYou scored: " + score.ToString();
        }
    }

    private void CaughtHighScore()
    {
        if (highscoreText != null)
        {
            highscoreText.text = "GAME OVER! \nFisherman caught you!\nYou scored: " + score.ToString();
        }
    }
}
