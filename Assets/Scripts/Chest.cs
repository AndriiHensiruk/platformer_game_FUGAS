using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Entity
{
    private void Start()
    {
        lives = 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.Instance.GetDamage();
            lives--;
        }

        if (lives < 1)
         Die();
    }
}
