using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float movingSpeed = 1f;
    [SerializeField] float jumpForce = 1f;
    bool facingRight = false;
    [SerializeField] Animator animator = null;
    private float moveInput;
    Vector3 direction;
    bool isGrounded = false;
    [SerializeField] Rigidbody2D rigidbody = null;
    [SerializeField] GameObject groundCheck = null;
    private void FixedUpdate()
    {
        CheckGround();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            moveInput = Input.GetAxis("Horizontal");
            direction = transform.TransformDirection(Vector3.right) * moveInput;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
            animator.SetInteger("playerState", 1); // Turn on run animation
            if (facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight == true && moveInput < 0)
            {
                Flip();
            }
        }
        else
        {
            if (isGrounded) animator.SetInteger("playerState", 0); // Turn on idle animation
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        if (!isGrounded) animator.SetInteger("playerState", 2); // Turn on jump animation
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
        isGrounded = colliders.Length > 1;
    }
}
