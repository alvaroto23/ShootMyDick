using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private List<GameObject> menuPauseObjects = new List<GameObject>();
    private bool pauseGame = false;

    public void ReturnGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseGame = !pauseGame;
        Time.timeScale = 1f;
        ButtonsEnableState();
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
        print("Exit");
    }


    private void ButtonsEnableState()
    {
        for (int i = 0; i < menuPauseObjects.Count; i++)
        {
            menuPauseObjects[i].SetActive(pauseGame);
        }
    }


    private void OnPause()
    {
        pauseGame = !pauseGame;

        if (pauseGame)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            ButtonsEnableState();
        }

        else if (!pauseGame)
        {
            Cursor.lockState= CursorLockMode.Locked;
            Time.timeScale = 1f;
            ButtonsEnableState();
        }
    }

}
