using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Entite
{
    [SerializeField] private int lives = 3;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject==Hero.Instantiate.gameObject)
        {
            Hero.Instantiate.GetDamage();
            lives--;
            Debug.Log("Worm" + lives);
        }
        if (lives < 1)
            Die();
    }
}

