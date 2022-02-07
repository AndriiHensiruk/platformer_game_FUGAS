using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Info : MonoBehaviour
{

    public Text ShowCoints;
    public Text ShowName;

    private int coins;
    private string name;

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("SaveCoint");
        ShowCoints.text = coins.ToString();

        name = PlayerPrefs.GetString("SaveName");
        ShowName.text = name.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
