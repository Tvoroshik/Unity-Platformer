using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if (sr.flipX == true)
            rb.AddForce(transform.right * 2, ForceMode2D.Force);
        else if(sr.flipX == false)
            rb.AddForce(-transform.right * 2, ForceMode2D.Force);
        SpawnFireball();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        Destroy(gameObject);
     }
    void SpawnFireball()
    {
        anim.SetInteger("Wizard", 1);
        if (sr.flipX == false)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            Instantiate(gameObject, new Vector2(-0.3f, transform.position.y), Quaternion.identity);
        }
        else if (sr.flipX == true)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            Instantiate(gameObject, new Vector2(0.3f, transform.position.y), Quaternion.identity);
        }

    }
}
