using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject camera2;
    [SerializeField] GameObject camera3;
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject aboutCanvas;
    [SerializeField] GameObject controlCanvas;

    private void Start()
    {
        camera2.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void About()
    {
        camera1.SetActive(false);
        camera2.SetActive(true);
        aboutCanvas.SetActive(true);
        menuCanvas.SetActive(false);

    }
    
    public void Controls()
    {
        camera1.SetActive(false);
        camera3.SetActive(true);
        controlCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Back()
    {
        camera1.SetActive(true);

        camera2.SetActive(false);

        camera3.SetActive(false);

        aboutCanvas.SetActive(false);

        controlCanvas.SetActive(false);

        menuCanvas.SetActive(true);

    }
}
