using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    private int currentScore;
    private int highScore;
    private bool gameIsPaused = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public GameObject gameGUI;
    public GameObject pauseMenu;

    public GameObject VictoryText;
    public GameObject DefeatedText;

    public GameObject[] enemyArray;

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
            if (!gameIsPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
        if(enemyArray.Length == 0)
        {
            if(currentScore > 50)
            {
                Success();

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
        gameGUI.SetActive(false);
        pauseMenu.SetActive(true);
        gameIsPaused = true;
        Cursor.visible = true;
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        gameGUI.SetActive(true);
        gameIsPaused = false;
        DefeatedText.SetActive(false);
        VictoryText.SetActive(false);
        Cursor.visible = false;
    }

    public void Defeated()
    {
        DefeatedText.SetActive(true);
        StartCoroutine(Delay3());
    }
    public void Success()
    {
        VictoryText.SetActive(true);
        StartCoroutine(Delay3());
    }

    IEnumerator Delay3()
    {
        yield return new WaitForSeconds(3);
        PauseGame();
    }
    public void EnemyCount()
    {
        GameObject.FindGameObjectsWithTag("Enemy");
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");

    }
}