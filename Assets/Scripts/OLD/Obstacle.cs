using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instantiate.gameObject)
        {
            Hero.Instantiate.GetDamage();
         }
                
     }
}
