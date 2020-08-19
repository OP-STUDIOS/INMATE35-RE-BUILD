using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CoverShooter;

public class GameMaster : MonoBehaviour
{
    public int currentScore;
    private int highScore;
    private bool gameIsPaused = false;
    private bool isGameOver = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public GameObject gameGUI;
    public GameObject pauseMenu;
    public GameObject crossHair;

    public GameObject gameWonView;
    public GameObject gameOverView;
    //public TextMeshProUGUI scoreText;
   // public TextMeshProUGUI highScoreText;

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
            if (!isGameOver)
            {
                if (!gameIsPaused)
                {
                    EnablePauseMenu();
                }
                else
                {
                    ResumeGame();
                }
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

    private void EnablePauseMenu()
    {
        pauseMenu.SetActive(true);
        PauseGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameGUI.SetActive(false);
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
        gameOverView.SetActive(false);
        gameWonView.SetActive(false);
    }

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        isGameOver = true;
        gameOverView.SetActive(true);
        yield return new WaitForSeconds(2f);
        PauseGame();
        pauseMenu.SetActive(false);
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
        isGameOver = true;
        gameWonView.SetActive(true);
        yield return new WaitForSeconds(2f);
        PauseGame();
        pauseMenu.SetActive(false);
        gameGUI.SetActive(false);
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}