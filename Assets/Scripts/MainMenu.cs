using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

   public void OnPlayBtnClick()
    {
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnOptionBtnClick()
    {
        SceneManager.LoadScene(3);
    }

    public void OnQuitBtnClick()
    {
        Application.Quit();
    }

}
