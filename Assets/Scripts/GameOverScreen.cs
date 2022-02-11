using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
   
    public GameObject gameOver;
   

    public void LoadManu()
    {
       Time.timeScale = 1f;
        SceneManager.LoadScene("manuScena");
    }

    public void RestartPlayer()
    {
       // PlayerPrefs.SetInt("PositionPlayer", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("SaveCoint", 0);
    }
}
