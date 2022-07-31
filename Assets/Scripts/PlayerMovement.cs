using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;



    private void Awake()
    {
        //Grab references for rigitbody and animator
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizonalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizonalInput * speed, body.velocity.y);

        //Flip left or right
        if (horizonalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizonalInput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);

         
        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        //Set animator param
        anim.SetBool("run", horizonalInput != 0);
        anim.SetBool("grounded", grounded);

    }

    private void Jump()
    {  
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;

    }
}

