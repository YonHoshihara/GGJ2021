using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moviment : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float jumpForce;
    public float dashForce;
    private float movement;
    [SerializeField] bool isGrounded;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;

    void Update() {
        Jump();
        Dash();
        movement = Input.GetAxis("Horizontal") * speed;
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            move(movement, true, false);
        }
    }

    private void Dash()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Dash");
            move(movement, false, true);
        }
    }
    private void FixedUpdate()
    {
        move(movement, false, false);
    }
    public void move(float move, bool jump, bool dash)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        if (jump)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce));
        }

        if (dash)
        {

            if (rb.velocity.x == 0)
            {
                rb.AddForce(new Vector2(dashForce, 0f));
            }
            if (rb.velocity.x > 0)
            {
                rb.AddForce(new Vector2(dashForce, 0f));
            }

            if (rb.velocity.x < 0)
            {
                rb.AddForce(new Vector2(-dashForce, 0));
            }
        }
    }
}
    