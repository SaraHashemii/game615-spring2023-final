using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{



    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
    public void MainMenuButton()
    {
        HandleMainMenuScene();
    }



    public void HandleEndScene()
    {
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.None;
    }


    public void HandleMainMenuScene()
    {
        SceneManager.LoadScene(2);
        Cursor.lockState = CursorLockMode.None;
    }

}
