using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelektor : MonoBehaviour
{
    public Button[] levels;
    // Start is called before the first frame update
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < levels.Length; i++)
            if (i + 1 > levelReached)
                levels[i].interactable = false;
    }

    public void Select( int numberInBuild)
    {
        SceneManager.LoadScene(numberInBuild);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
