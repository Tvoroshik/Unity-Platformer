using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public GameObject fireball;
    SpriteRenderer sr;
    Animator anim;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (GameObject.Find("Player").transform.position.x < transform.position.x)
            sr.flipX = false;
        else
            if (GameObject.Find("Player").transform.position.x > transform.position.x)
            sr.flipX = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            SpawnFireball();
     }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetInteger("Wizard", 2);

            Destroy(gameObject, 0.5f);

        }
    }
  
    void SpawnFireball()    
    {
        anim.SetInteger("Wizard", 1);
            if (sr.flipX==false)
        {
            fireball.GetComponent<SpriteRenderer>().flipX=false;
            Instantiate(fireball, new Vector2(-0.3f, transform.position.y), Quaternion.identity);
        }
        else if(sr.flipX==true)
         {
            fireball.GetComponent<SpriteRenderer>().flipX = true;
            Instantiate(fireball, new Vector2(0.3f, transform.position.y), Quaternion.identity);
         }
        
    }
}


