using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float speedJump = 400f;

    public bool jump = false;
    public bool isGrounded = false;

    Vector2 maxVelocity = new Vector2(5, 5);

    public Animator animator;
    public Rigidbody2D rb;
    public SpriteRenderer _spriteRenderer;

    public Transform GroundCheck, GroundCheckL, GroundCheckR;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!jump && isGrounded)
            {
                jump = true;
            }
        }
        Debug.DrawLine(transform.position, GroundCheck.position, Color.red);
        Debug.DrawLine(transform.position, GroundCheckL.position, Color.blue);
        Debug.DrawLine(transform.position, GroundCheckR.position, Color.yellow);
    }

    private void FixedUpdate()
    {
        float forceX = 0f;
        float forceY = 0f;

        if (jump)
        {
            forceY = speedJump;
        }
        if (Physics2D.Linecast(transform.position, GroundCheck.position, groundLayer) ||
            Physics2D.Linecast(transform.position, GroundCheckL.position, groundLayer) ||
            Physics2D.Linecast(transform.position, GroundCheckR.position, groundLayer))
        {
            isGrounded = true;
            jump = false;
        }
        else
        {
            isGrounded = false;
        }

        Vector2 v2 = new Vector2(forceX, forceY);
        rb.AddForce(v2);
    }
}
