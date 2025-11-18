using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 5f;
    public float pushSpeed;
    private bool pushing = false;
    private bool inputEnabled = true;
    public Animator animator;
    private Rigidbody2D rb2d;
    public GameObject yeti;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (inputEnabled)
        {
            float xInput = Input.GetAxis("Horizontal") * speed;
            float yInput = pushSpeed;

            pushing = Input.GetAxis("Vertical") < 0;

            if (pushing)
            {
                pushSpeed = -15f;
            }
            else
            {
                if (pushSpeed < 0f)
                {
                    pushSpeed += 0.1f;
                }
            }

            rb2d.linearVelocity = new Vector2(xInput, yInput);
            animator.SetBool("Pushing", pushing);
        }
        else
        {
            // Stop the skier completely when input is disabled
            rb2d.linearVelocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Disable input when hit by Yeti
        if (collision.gameObject == yeti)
        {
            inputEnabled = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Re-enable input if Yeti releases skier (for testing flexibility)
        if (collision.gameObject == yeti)
        {
            inputEnabled = true;
        }
    }
}
