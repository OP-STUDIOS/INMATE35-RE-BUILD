using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private float roundTime = 30f;
    [SerializeField]
    private float roundSpeed = 1f;
    [SerializeField]
    private int winningScore = 150;

    private bool timerReset = false;
    private GameMaster _gameMaster;

    private void Start()
    {
        _gameMaster = FindObjectOfType<GameMaster>();
    }

    private void FixedUpdate()
    {
        //Round Timer
        roundTime -= Time.unscaledDeltaTime * roundSpeed;

        var newRoundTime = Mathf.Clamp(roundTime, 0f, roundTime);
        if (newRoundTime <= 0 && !timerReset)
        {
            timerReset = true;
            int cScore = FindObjectOfType<GameMaster>().currentScore;
            if (cScore >= winningScore)
            {
                _gameMaster.GameWon();
            }
            else
            {
                _gameMaster.GameOver();
            }      
        }
        //Round Timer
    }
}
