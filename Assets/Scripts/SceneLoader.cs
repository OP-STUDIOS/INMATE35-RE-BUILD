using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OnResumeBtnClick()
    {
        FindObjectOfType<GameMaster>().ResumeGame();
    }

    public void OnMainMenuBtnClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnPlayMenuBtnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void RePlayBtnClick()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void OnQuitBtnClick()
    {
        Application.Quit();    
    }
}
