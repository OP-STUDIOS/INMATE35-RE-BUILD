using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CoverShooter;

public class SlowMotionManager : MonoBehaviour
{
    public Image clockSlider;
    public GameObject camerastart;
    private SFX_Manager sfx_Manager;

    public float slowMoSlider = 1;

    public bool UsingSlowMo = false;
    private bool autoReset = false;


    private void Awake()
    {
        Time.timeScale = 1.0f;
        camerastart.GetComponent<Transform>().position = new Vector3(-56.64461f, 5.690623f, 20.4315f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Start()
    {
        sfx_Manager = FindObjectOfType<SFX_Manager>();
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
            if (Time.timeScale == 1.0f)
            {
                SlowMotionOn();
            }
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (!autoReset)
            {
                SlowMotionOff();
            }
        }


        if (slowMoSlider == 0)
        {
            autoReset = true;
            SlowMotionOff();
        }

        if (slowMoSlider >= 0.95)
        {
            if (UsingSlowMo == false)
            {
                slowMoSlider = 1f;
                SlowMotionOff();
            }
        }
        clockSlider.fillAmount = slowMoSlider;
    }

    public void SlowMotionOn()
    {
        Time.timeScale = 0.25f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        GameObject.FindWithTag("Player").GetComponent<CharacterMotor>().Speed = 4f;
        UsingSlowMo = true;
        sfx_Manager.PlaySound("SlowMoEnter");
        sfx_Manager.PlaySoundOnLoop("SlowMoMiddle");
        autoReset = false;
    }

    public void SlowMotionOff()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        GameObject.FindWithTag("Player").GetComponent<CharacterMotor>().Speed = 1f;
        UsingSlowMo = false;
        sfx_Manager.PlaySound("SlowMoExit");
        sfx_Manager.StopSound("SlowMoMiddle");
    }
}