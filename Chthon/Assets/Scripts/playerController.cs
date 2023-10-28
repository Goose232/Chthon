using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public Animator animator;


    void Start()
    {
      
    }

   
    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        if (movementX > 0 || movementX < 0)
        {
            animator.SetBool("isRunning", true);  
        }

            else
                {
            animator.SetBool("isRunning", false);        
                }



        if (Input.GetButtonDown("Jump") && isGrounded())
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movementX * playerSpeed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, grounLayer);
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
