using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        FindObjectOfType<Swicher>().enabled = true;      
        Weapon wn = FindObjectOfType<Weapon>();
        if (wn != null)
        {
            wn.enabled = true;
        }      
        GranadeThrower gThrow = FindObjectOfType<GranadeThrower>();
        if (gThrow != null)
        {
            gThrow.enabled = true;
        }
        Cursor.lockState = CursorLockMode.Locked;
        GameIsPaused = false;
        Time.timeScale = 1f; // unfreeze the game
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // freeze the game
        Weapon wn = FindObjectOfType<Weapon>();
        if(wn != null)
        {
            wn.enabled = false;
        }
        GranadeThrower gThrow = FindObjectOfType<GranadeThrower>();
        if (gThrow != null)
        {
            gThrow.enabled = false;
        }
        FindObjectOfType<Swicher>().enabled = false;      
        Cursor.lockState = CursorLockMode.None;       
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
