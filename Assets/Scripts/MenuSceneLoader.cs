using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneLoader : MonoBehaviour
{
    public GameObject playBtnSubText;
    public GameObject recordsBtnSubText;
    public GameObject optionsBtnSubText;
    public GameObject quitBtnSubText;

    public void OnMenuPlayBtnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnMenuQuitBtnClick()
    {
        Application.Quit();
    }

    public void OnPointerEnterPlayBtn()
    {
        playBtnSubText.SetActive(true);
    }

    public void OnPointerExitPlayBtn()
    {
        playBtnSubText.SetActive(false);
    }

    public void OnPointerEnterRecordsBtn()
    {
        recordsBtnSubText.SetActive(true);
    }

    public void OnPointerExitRecordsBtn()
    {
        recordsBtnSubText.SetActive(false);
    }

    public void OnPointerEnterOptionsBtn()
    {
        optionsBtnSubText.SetActive(true);
    }

    public void OnPointerExitOptionsBtn()
    {
        optionsBtnSubText.SetActive(false);
    }

    public void OnPointerEnterQuitBtn()
    {
        quitBtnSubText.SetActive(true);
    }

    public void OnPointerExitQuitBtn()
    {
        quitBtnSubText.SetActive(false);
    }
}
