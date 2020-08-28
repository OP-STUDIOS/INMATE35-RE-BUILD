using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CoverShooter;
using UnityEngine.Rendering.PostProcessing;

public class SlowMotionManager : MonoBehaviour
{
    public Material EnemySlowMoMaterial;
    public Material EnemyDefaultMaterial;

    public Image clockSlider;
    public GameObject camerastart;
    private SFX_Manager sfx_Manager;
    private GameMaster gameMaster;
    private CharacterMotor playerCharacterMotor;
    public Camera cam;
    public GameObject cinemaEffect;

    public float slowMoSlider = 1;
    public float slowMoDuration = 0.8f;
    public float slowMoGeneration = 0.8f;

    public bool UsingSlowMo = false;
    private bool autoReset = false;


    private void Awake()
    {
        Time.timeScale = 1.0f;
        camerastart.GetComponent<Transform>().position = new Vector3(-56.64461f, 5.690623f, 20.4315f);
    }

    private void Start()
    {
        sfx_Manager = FindObjectOfType<SFX_Manager>();
        gameMaster = FindObjectOfType<GameMaster>();
        playerCharacterMotor = GameObject.FindWithTag("Player").GetComponent<CharacterMotor>();
    }

    private void LateUpdate()
    {
        SlowMoSliderUpdate();
    }

    private void Update()
    {
        SlowMotionInput();
    }

    private void SlowMotionInput()
    {
        slowMoSlider = Mathf.Clamp(slowMoSlider, 0, 1);
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (Time.timeScale == 1.0f && !gameMaster.isStarting && !gameMaster.gameIsPaused)
            {
                SlowMotionOn();
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse1) )
        {
            if (!autoReset && UsingSlowMo)
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

    private void SlowMoSliderUpdate()
    {
        if (UsingSlowMo)
        {
            slowMoSlider -= slowMoDuration * Time.deltaTime;
        }
        else
        {
            slowMoSlider += slowMoGeneration * Time.deltaTime;
        }
    }

    private void SlowMotionOn()
    {
        Time.timeScale = 0.25f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        UsingSlowMo = true;
        autoReset = false;
        playerCharacterMotor.Speed = 4f;
        sfx_Manager.PlaySound("SlowMoEnter");
        sfx_Manager.PlaySoundOnLoop("SlowMoMiddle");
        cam.GetComponent<PostProcessLayer>().enabled = true;
        ChangeEnemyMaterialToSlowMo();
        cinemaEffect.SetActive(true);
    }

    private void SlowMotionOff()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        UsingSlowMo = false;
        playerCharacterMotor.Speed = 1f;
        sfx_Manager.PlaySound("SlowMoExit");
        sfx_Manager.StopSound("SlowMoMiddle");
        cam.GetComponent<PostProcessLayer>().enabled = false;
        ChangeEnemyMaterialToDefault();
        cinemaEffect.SetActive(false);
    }
    private void ChangeEnemyMaterialToSlowMo()
    {
        GameObject[] _enimies;
        _enimies = GameObject.FindGameObjectsWithTag("Enemy");
        if (_enimies != null)
        {
            for (int i = 0; i < _enimies.Length; i++)
            {
                _enimies[i].GetComponentInChildren<SkinnedMeshRenderer>().material = EnemySlowMoMaterial;
            }
        }
    }

    private void ChangeEnemyMaterialToDefault()
    {
        GameObject[] _enimies;
        _enimies = GameObject.FindGameObjectsWithTag("Enemy");
        if (_enimies != null)
        {
            for (int i = 0; i < _enimies.Length; i++)
            {
                _enimies[i].GetComponentInChildren<SkinnedMeshRenderer>().material = EnemyDefaultMaterial;
            }
        }
    }
}