using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilManeger : MonoBehaviour
{
    public GameObject InputPanel;
   

    public InputField InName;


    public Text ShowName;

    public void Next()
    {
        InputPanel.SetActive(false);
       
        ShowName.text = InName.text;

        PlayerPrefs.SetString("SaveName", ShowName.text);

    }
}
