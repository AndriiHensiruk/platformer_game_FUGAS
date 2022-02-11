using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    public GameObject youWin;


    public void LoadManu()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("manuScena");
    }

    public void QuitGame()
    {
        Application.Quit();
        
    }
}
