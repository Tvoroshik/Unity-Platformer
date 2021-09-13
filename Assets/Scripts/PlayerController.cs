using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool ground;
    Rigidbody2D rb;
    Animator anim;
    public BoxCollider2D boxCollider2D;
    public BoxCollider2D boxCollider2;
    SpriteRenderer sr;
    int punchCount;


    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
     }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S))
            rb.velocity = new Vector2(Input.GetAxis("Horizontal"), rb.velocity.y);
        if (Input.GetAxis("Horizontal") == 0)
            anim.SetInteger("anim", 0);
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
            anim.SetInteger("anim", 1);
        if (Input.GetAxis("Horizontal") > 0)
            sr.flipX = false;
        else if (Input.GetAxis("Horizontal") < 0)
            sr.flipX = true;
        if (Input.GetKey(KeyCode.S))
            Crouch();
        if (Input.GetKeyUp(KeyCode.S))
            CrouchOff();
        if (Input.GetKey(KeyCode.S) && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
            CrouchKick();
        if (Input.GetKeyDown(KeyCode.W) && ground == true)
            Jump();
        if (ground == false && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
            FlyingKick();
        else if (ground == false && (!Input.GetKeyDown(KeyCode.A) || !Input.GetKeyDown(KeyCode.D)))
            anim.SetInteger("anim", 5);
        if (Input.GetKeyDown(KeyCode.W) && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
            Kick();
       if (Input.GetMouseButton(0))
        {
            Punch();
        }


    }
  
    void Punch()
    {
        anim.SetInteger("anim", 9);
     }
    void Kick()
    {
        anim.SetInteger("anim", 8);
    }
    void Hurt()
    {
        anim.SetInteger("anim", 7);
    }
    void FlyingKick()
    {
        anim.SetInteger("anim", 6);
    }
    void CrouchKick()
    {
        anim.SetInteger("anim", 4);
            }
   
    void Crouch()
    {
        anim.SetInteger("anim", 3);
        boxCollider2D.enabled = false;
        boxCollider2.enabled = true;
    }
    void CrouchOff()
    {
        anim.SetInteger("anim", 3);
        boxCollider2D.enabled = true;
        boxCollider2.enabled = false;
    }
    void Jump()
    {
        anim.SetInteger("anim", 2);
        rb.AddForce(transform.up*3, ForceMode2D.Impulse);
    }

}
