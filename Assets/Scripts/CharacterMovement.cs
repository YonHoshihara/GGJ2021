using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public string groundTag;
    [SerializeField] private float jumpForce;
    [SerializeField] private float dashForce;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] bool isGrounded;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;
    public bool right;
    public bool left;

    private void Start()
    {
        isGrounded = true;
    }
    public void Jump(float movement)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            move(movement, true, false);
        }
    }

    public void Dash(float movement)
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Dash");
            move(movement, false, true);
        }
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

    public void CheckLookAt()
    {

        if (rb.velocity.x == 0)
        {
            right = true;
            left = false;
        }

        if (rb.velocity.x > 0)
        {
            right = true;
            left = false;
        }

        if (rb.velocity.x < 0)
        {
            right = false;
            left = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == groundTag)
        {
            isGrounded = true;
        }
    }
}
