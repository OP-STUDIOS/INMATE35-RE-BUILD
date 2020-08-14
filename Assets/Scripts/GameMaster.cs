using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CoverShooter;

public class GameMaster : MonoBehaviour
{
    private int currentScore;
    private int highScore;
    private bool gameIsPaused = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public GameObject gameGUI;
    public GameObject pauseMenu;
    public GameObject crossHair;

    public GameObject VictoryText;
    public GameObject DefeatedText;

    private void Start()
    {
        currentScore = 0;
        highScore = PlayerPrefs.GetInt("HighScore");
        UpdateCurrentScoreText();
        UpdateHighScoreText();
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void UpdateCurrentScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    public void UpdateHighScoreText()
    {
        highScoreText.text = highScore.ToString();
    }

    public void AddScore()
    {
        currentScore += 5;
        UpdateCurrentScoreText();
        int cHighScore = PlayerPrefs.GetInt("HighScore");
        if (currentScore > cHighScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameGUI.SetActive(false);
        pauseMenu.SetActive(true);
        crossHair.SetActive(false);
        FindObjectOfType<ThirdPersonInput>().isCharacterPaused = true;
        gameIsPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        gameGUI.SetActive(true);
        crossHair.SetActive(true);
        FindObjectOfType<ThirdPersonInput>().isCharacterPaused = false;
        gameIsPaused = false;
        DefeatedText.SetActive(false);
        VictoryText.SetActive(false);
    }

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        DefeatedText.SetActive(true);
        yield return new WaitForSeconds(2f);
        gameGUI.SetActive(false);
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void GameWon()
    {
        StartCoroutine(GameWonRoutine());
    }

    IEnumerator GameWonRoutine()
    {
        VictoryText.SetActive(true);
        yield return new WaitForSeconds(2f);
        gameGUI.SetActive(false);
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}