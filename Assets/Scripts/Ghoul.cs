using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : MonoBehaviour
{
    SpriteRenderer sr;
    Animator anim;
    Rigidbody2D rb;
    public int distance;
    float minDistance;
    float maxDistance;
    int speed = 1;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        maxDistance = transform.position.x + distance;
        minDistance = transform.position.x - distance;
    }
    private void FixedUpdate()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
        if (transform.position.x > maxDistance)
        {
            sr.flipX = false;
            speed = -speed;
        }
            
         if (transform.position.x < minDistance)
        {
            sr.flipX = true;
            speed = -speed;
        }
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetInteger("Ghoul", 1);
            Invoke("Destroy", 0.5f);
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}

