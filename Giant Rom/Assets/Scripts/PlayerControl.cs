using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    bool facingRight = true;
    public float maxSpeed;
    public float jumpForce;
    Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.4f;
    public LayerMask whatIsGround;

    public AudioClip[] audioFiles;
    public Camera mainCamera;

    private AudioSource source;
    private bool resetCamera;
    public StatBar powerBar;

    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        powerBar.ChangeBar(0.0005f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
        float move = 0.0f;
        if (mainCamera.orthographicSize > 1.2f)
        {
            move = Input.GetAxis("Horizontal");
        }
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

        if (powerBar.GetFillamount() == 1.0f && Input.GetKeyUp(KeyCode.Alpha4) && !resetCamera)
        {
            resetCamera = true;
            StartCoroutine(ZoomInCamera(audioFiles[0], 0.75f, 2.0f));
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

    private IEnumerator ZoomInCamera(AudioClip audioClip, float zoom, float speed)
    {
        Vector3 cameraDefaultPos = mainCamera.transform.position;
        float cameraDefaultSize = mainCamera.orthographicSize;

        while (mainCamera.orthographicSize > zoom)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, this.transform.position + new Vector3(0.0f, 0.0f, -0.3f), Time.deltaTime * speed);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, zoom-0.05f, Time.deltaTime * speed);
            yield return null;
        }
        if (!source.isPlaying)
        {
            source.PlayOneShot(audioClip, 1);
        }
        //comedic timing.
        yield return new WaitForSeconds(audioClip.length + 0.5f);
        GameManager.gameManager.SetDemonstration(3);

        while (mainCamera.orthographicSize < cameraDefaultSize)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraDefaultPos, Time.deltaTime * speed);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, cameraDefaultSize + 0.05f, Time.deltaTime * speed);
            yield return null;
        }
        powerBar.SetFillAmount(0.0f);
        resetCamera = false;
    }
}
