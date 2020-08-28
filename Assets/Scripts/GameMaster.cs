using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CoverShooter;

public class GameMaster : MonoBehaviour
{
    public int currentScore;
    private int highScore;
    public bool gameIsPaused = false;
    public bool isStarting = true;
    private bool isGameOver = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI gameWonHighScoreTxt;
    public TextMeshProUGUI gameWonCurrentScoreTxt;
    public TextMeshProUGUI gameOverHighScoreTxt;
    public TextMeshProUGUI gameOverCurrentScoreTxt;

    public GameObject gameGUI;
    public GameObject pauseMenu;
    public GameObject crossHair1;
    public GameObject crossHair2;

    public GameObject gameWonView;
    public GameObject gameOverView;


    private void Awake()
    {
        StartCoroutine(PauseOnStartUp());
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //Start the scene with cursor locked and not visible
    }

    private void Start()
    {
        currentScore = 0;
        highScore = PlayerPrefs.GetInt("HighScore");
        UpdateCurrentScoreText();
        UpdateHighScoreText();
        pauseMenu.SetActive(false);    
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
        crossHair1.SetActive(false);
        crossHair2.SetActive(false);
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
        FindObjectOfType<ThirdPersonInput>().isCharacterPaused = false;
        gameIsPaused = false;
        gameOverView.SetActive(false);
        gameWonView.SetActive(false);

        if (!isStarting)
        {
            crossHair1.SetActive(true);
            crossHair2.SetActive(true);
        }
        //Check if it's start of the game
    }

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        isGameOver = true;
        gameOverView.SetActive(true);
        gameOverHighScoreTxt.text = highScore.ToString();
        gameOverCurrentScoreTxt.text = currentScore.ToString();
        PauseGame();
        pauseMenu.SetActive(false);
        gameGUI.SetActive(false);
        yield return new WaitForSeconds(2f);
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
        gameWonHighScoreTxt.text = highScore.ToString();
        gameWonCurrentScoreTxt.text = currentScore.ToString();
        PauseGame();
        pauseMenu.SetActive(false);
        gameGUI.SetActive(false);
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    IEnumerator PauseOnStartUp()
    {
        isStarting = true;
        crossHair1.SetActive(false);
        crossHair2.SetActive(false);
        yield return new WaitForSecondsRealtime(9f);
        isStarting = false;
        crossHair1.SetActive(true);
        crossHair2.SetActive(true);
    }
}