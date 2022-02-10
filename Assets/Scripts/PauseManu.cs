using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManu : MonoBehaviour
{
    private bool PauseGame;
    public GameObject pauseGameManu;
   

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            } else
            {
                Pause();
            }

        } 
    }

    public void Resume()
    {
        pauseGameManu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void Pause ()
    {
        pauseGameManu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void LoadManu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("manuScena");
    }

    public void RestartPlayer()
    {
        PlayerPrefs.SetInt("PositionPlayer", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
