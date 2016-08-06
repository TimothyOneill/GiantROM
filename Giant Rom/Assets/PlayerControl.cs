using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    Rigidbody2D rigidbody2D;
    bool facingRight = true;
    public float maxSpeed;
    public float jumpForce;
    Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.4f;
    public LayerMask whatIsGround;

    public AudioClip[] audio;


    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rigidbody2D.velocity.y);


        float move = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
        anim.SetFloat("hSpeed", Mathf.Abs(move));

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    void Update()
    {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    //Flips the character to face the correct direction
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //Makes the character jump
    public void Jump()
    {
        anim.SetBool("Ground", false);
        rigidbody2D.AddForce(new Vector2(0, jumpForce));
    }
}
