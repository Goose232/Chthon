using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
   
    private float movementX;
    private bool isFacingRight = true;

    public float playerSpeed = 10;
    public float jumpForce = 5;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask grounLayer;

    [SerializeField] private Transform ObstacleCheck;
    [SerializeField] private LayerMask obstacle;

    public Animator animator;


    void Start()
    {
      
    }

   
    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        if (movementX > 0 || movementX < 0)
        { 
            animator.SetBool("isStopping", false);
            animator.SetBool("isRunning", true);
            animator.SetBool("isPushing", false);
            animator.SetBool("isRunJumping", false);

            if (isPushed())
            {
                animator.SetBool("isPushing", true);
                animator.SetBool("isStopping", false);
                animator.SetBool("isRunning", false);
            }

        }

                else
                {
                    animator.SetBool("isRunning", false);
                    animator.SetBool("isStopping", true);
                    animator.SetBool("isPushing", false);
                    animator.SetBool("isRunJumping", false);
        }



        if (Input.GetButtonDown("Jump") && (isGrounded() || isBoxed()))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isRunJumping", true);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            
        }

        

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movementX * playerSpeed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.4f, grounLayer);
    }

    private bool isBoxed()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, obstacle);
    }

    private bool isPushed()
    {
        return Physics2D.OverlapCircle(ObstacleCheck.position, 0.5f, obstacle);
    }

    private void Flip()
    {
        if (isFacingRight && movementX <0f || !isFacingRight && movementX > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            
        }
    }

    
}
