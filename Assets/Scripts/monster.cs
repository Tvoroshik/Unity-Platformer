using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster: Entite
{

    private Vector3 dir;
    private SpriteRenderer sprite;
    private void Start()
            {
        dir = transform.right;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position+transform.up*0.1f+transform.right*dir.x*0.7f,0.1f);
        if (collider.Length > 0) dir *= -1f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
            
            }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject==Hero.Instantiate.gameObject)
        {
            Hero.Instantiate.GetDamage();
        }
    }
   


}
