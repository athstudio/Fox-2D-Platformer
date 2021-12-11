using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody2D playerRB2D;

    private bool isGrouded;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] LayerMask whatIsGround;

    private bool canDoubleJump;
    private Animator anim;
    private SpriteRenderer playerSR;

    
    void Start()
    {
        anim = GetComponent<Animator>();

        playerSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();

        Jump();

        Flip();

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

    private void Animated()
    {
        anim.SetFloat("moveSpeed",Mathf.Abs(playerRB2D.velocity.x));
        anim.SetBool("isGrounded", isGrouded);
    }
}
