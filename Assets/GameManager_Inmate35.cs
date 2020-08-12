using CoverShooter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Inmate35 : MonoBehaviour
{
    public Image clockSlider;
    public AudioSource slowMoStart;

    public AudioSource slowMoDuring;

    public AudioSource slowMoEnd;
    public float movespeed;
    
    public float slowMoSlider;
    public GameObject camerastart;

    public bool UsingSlowMo = false;
    private void Awake()
    {
        Time.timeScale = 1.0f;
        camerastart.GetComponent<Transform>().position = new Vector3(-56.64461f, 5.690623f, 20.4315f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void LateUpdate()
    {
        if (UsingSlowMo)
        {
            slowMoSlider -= 0.5f * Time.deltaTime;
        }
        else
        {
            slowMoSlider += 0.1f * Time.deltaTime;
        }
    }
    private void Update()
    {
        slowMoSlider = Mathf.Clamp(slowMoSlider, 0, 1);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(Time.timeScale == 1.0f)
            {
                SlowMotionOn();
            }
            else
            {
                SlowMotionOff();
            }
        }

        
        if (slowMoSlider == 0)
        {
            SlowMotionOff();
        }
        if (slowMoSlider >= 0.8)
        {
            if (UsingSlowMo == false)
            {
                slowMoSlider = 1f;
                SlowMotionOff();
            }
        }

        Debug.Log(slowMoSlider);

        clockSlider.fillAmount = slowMoSlider;

    }

    public void SlowMotionOn()
    {
        Time.timeScale = .25f;
        GameObject.FindWithTag("Player").GetComponent<CharacterMotor>().Speed = 3f;
        UsingSlowMo = true;
        slowMoStart.Play();
        slowMoDuring.Play();
    }

    public void SlowMotionOff()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        GameObject.FindWithTag("Player").GetComponent<CharacterMotor>().Speed = 1f;
        UsingSlowMo = false;
        slowMoEnd.Play();
        slowMoDuring.Stop();
    }
    
}
