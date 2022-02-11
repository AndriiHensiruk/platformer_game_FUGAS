using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LastFinish : MonoBehaviour
{
    [SerializeField] GameObject WinerSkreen;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            WinerSkreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
