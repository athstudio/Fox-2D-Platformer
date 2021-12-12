using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody2D playerRB2D;

    private bool isGrouded;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] LayerMask whatIsGround;

    private bool canDoubleJump;
    private Animator anim;
    private SpriteRenderer playerSR;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    private void Awake() 
    {
        instance = this;
    }
    
    void Start()
    {
        anim = GetComponent<Animator>();

        playerSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(knockBackCounter <= 0)
        {
            Move();

            Jump();

            Flip();
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
            if(!playerSR.flipX)
            {
                playerRB2D.velocity = new Vector2(-knockBackForce, playerRB2D.velocity.y);
            }
            else
            {
                playerRB2D.velocity = new Vector2(knockBackForce, playerRB2D.velocity.y);
            }
        }

        Animated();
    }

 
    private void Move()
    {
         playerRB2D.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), playerRB2D.velocity.y);
    }

    private void Jump()
    {
        isGrouded = Physics2D.OverlapCircle(groundCheckPoint.position, .1f, whatIsGround);

        if(isGrouded)
        {
            canDoubleJump = true;
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(isGrouded)
            {
                playerRB2D.velocity = new Vector2(playerRB2D.velocity.x, jumpForce);
            }
            else 
            {
                if(canDoubleJump)
                {
                    playerRB2D.velocity = new Vector2(playerRB2D.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
        }
    }

    private void Flip()
    {
        if(playerRB2D.velocity.x < 0)
        {
            playerSR.flipX = true;
        }
        else if(playerRB2D.velocity.x > 0)
        {
            playerSR.flipX = false;
        }
    }

   public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        playerRB2D.velocity = new Vector2(0f, knockBackForce);

        anim.SetTrigger("hurt");
    }

    private void Animated()
    {
        anim.SetFloat("moveSpeed",Mathf.Abs(playerRB2D.velocity.x));
        anim.SetBool("isGrounded", isGrouded);
    }

}
