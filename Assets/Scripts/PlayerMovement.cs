using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxColider;
    private float wallJumpCooldown;
    private float horizontalInput;


    private void Awake()
    {
        //Grab references for rigitbody and animator
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxColider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Flip left or right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);

        //Set animator param
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());


        //WallJumpLogic
        //print(onWall());
        if (wallJumpCooldown < 0.2f)
        {
          
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else 
                body.gravityScale = 7;

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
         else 
                wallJumpCooldown += Time.deltaTime;
    }

    private void Jump()
    {  
        if(isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector2(-Mathf.Sign(transform.localScale.x), transform.localScale.z);
            }
            else
            body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 4, 6);

            wallJumpCooldown = 0;
        }
  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
 
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxColider.bounds.center, boxColider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider!=null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxColider.bounds.center, boxColider.bounds.size, 0,new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
}

