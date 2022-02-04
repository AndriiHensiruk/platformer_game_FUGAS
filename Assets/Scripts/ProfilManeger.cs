using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilManeger : MonoBehaviour
{
    public GameObject InputPanel;
    public GameObject ShowLevel;

    public InputField InName;

    public Text ShowName;
    public Text ShowCoints;

    public void Next()
    {
        InputPanel.SetActive(false);
        ShowLevel.SetActive(true);

        ShowName.text = InName.text;
        ShowCoints.text = GetComponent<Player>().score.ToString();
    }
}
