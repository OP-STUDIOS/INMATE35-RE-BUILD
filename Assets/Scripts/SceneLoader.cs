using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OnResumeBtnClick()
    {
        FindObjectOfType<GameMaster>().ResumeGame();
        Debug.Log("ResumeClicked");
        Cursor.visible = false;
    }

    public void OnMainMenuBtnClick()
    {
        SceneManager.LoadScene(0);
        Debug.Log("MainClicked");
        Cursor.visible = true;
    }

    public void OnPlayMenuBtnClick()
    {
        SceneManager.LoadScene(1);
        Debug.Log("PlayClicked");
        
    }

    public void OnQuitBtnClick()
    {
        Application.Quit();
        Debug.Log("QuitClicked");
        
    }

}
