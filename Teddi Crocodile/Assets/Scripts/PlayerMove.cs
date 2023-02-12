using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    

    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    


    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    private float dirX = 0f;


    [SerializeField] private LayerMask platform;
    [SerializeField] private LayerMask jumpGround;

    private enum MovementState { idle, running, jumping, fallingJump }


    private void Start()
    {
        AudioManager.Instance.PlayMusic("GameMusic");
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        
    }
    private void Update()
    {
        Jump();
    }
    private void FixedUpdate()
    { 
        Run();
        AnimationUpdate();
        Jump();
    }

   

    private void AnimationUpdate()
    {
        MovementState state;


        if (dirX > 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = true;
            
        }
        else
        {

            state = MovementState.idle;
        }
        if (rb2D.velocity.y > .1f && !isPlatform())
        {
            state = MovementState.jumping;
        }
        else if (rb2D.velocity.y < -.1f && !isPlatform())
        {
            state = MovementState.fallingJump;

        }
        animator.SetInteger("state", (int)state);
    }

    public void Run()
    {
        dirX = SimpleInput.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(dirX * moveSpeed, rb2D.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && (isGrounded() || isPlatform()))
        {
            AudioManager.Instance.PlaySFX("JumpSound"); 
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
    }

    public void OnJumpButtonDown()
    {
        if (isGrounded() || isPlatform())
        {
            AudioManager.Instance.PlaySFX("JumpSound");
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            moveSpeed = 0;
            jumpForce = 0;
        }
        if (collision.gameObject.CompareTag("Wather"))
        {
            moveSpeed = 0;
            jumpForce = 0;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .3f, jumpGround);

    }
    private bool isPlatform()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .2f, platform);
    }
}
