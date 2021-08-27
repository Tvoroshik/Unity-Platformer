using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public BoxCollider2D boxCollider2D;
    public BoxCollider2D boxCollider2;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
     }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), rb.velocity.y);
        if (Input.GetAxis("Horizontal") != 0)
            anim.SetInteger("anim", 1);
        if(Input.GetKeyDown(KeyCode.S))
            Crouch();
        if (Input.GetKeyUp(KeyCode.S))
            CrouchOff();
        if (Input.GetKeyDown(KeyCode.W))
            Jump();

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