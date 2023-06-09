using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{



    public void RestartButton()
    {
        HandleGameScene();
    }

    public void MainMenuButton()
    {
        HandleMainMenuScene();
    }

    public void PlayButton()
    {
        HandleGameScene();
    }


    public void HandleEndScene()
    {
        SceneManager.LoadScene(2);
        Cursor.lockState = CursorLockMode.None;
    }

    public void HandleMainMenuScene()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
    }

    public void HandleGameScene()
    {
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void HandleVictoryScene()
    {

        SceneManager.LoadScene(3);
        Cursor.lockState = CursorLockMode.None;
    }




}
