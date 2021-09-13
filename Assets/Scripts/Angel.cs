using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    bool attack;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
     }
    private void FixedUpdate()
    {
        if (attack == true)
        {
            anim.SetInteger("Angel", 1);
            transform.position = Vector2.Lerp(transform.position, GameObject.Find("Player").transform.position, Time.deltaTime);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            attack = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetInteger("Angel", 2);
            Destroy(gameObject, 0.5f);
        }
            
    }

}
