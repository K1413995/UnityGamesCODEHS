using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YetiControls : MonoBehaviour
{
    // Variables and Classes
    public Animator animator;
    public float speed = 10f;
    public float distance = 6f;

    // === Behavior Toggles ===
    public bool moveRight = false;       // Run straight to the right
    public bool moveDownRight = false;   // Run diagonally down-right
    public bool moveLeft = false;        // Run straight to the left
    public bool followPlayer = false;    // Chase skier

    public GameObject player;
    public GameObject mainCamera;        // Renamed from "camera" to avoid CS0108 warning
    public AudioClip roar;

    private AudioSource audioSource;
    private Rigidbody2D rb2d;
    private Vector2 direction;

    void Start()
    {
        rb2d = player.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Trigger Yeti movement when skier enters the trigger distance
        if (player.transform.position.y < transform.position.y + distance)
        {
            // --- Yeti AI Behaviors ---
            if (followPlayer)
            {
                direction = new Vector2(
                    player.transform.position.x - transform.position.x,
                    player.transform.position.y - transform.position.y
                );
            }
            else if (moveDownRight)
            {
                direction = new Vector2(1, -1);
            }
            else if (moveLeft)
            {
                direction = new Vector2(-1, 0);
            }
            else if (moveRight)
            {
                direction = new Vector2(1, 0);
            }
            else
            {
                direction = Vector2.zero;
            }

            direction.Normalize();
            transform.Translate(direction * Time.deltaTime * speed);
            animator.SetFloat("Speed", speed);
        }

        // Stop Yeti when it goes offscreen or skier reaches bottom
        if (transform.position.x > 15 | transform.position.x < -13 | player.transform.position.y < -10)
        {
            speed = 0;
            animator.SetFloat("Speed", 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            // Play roar audio once
            if (audioSource != null && roar != null && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(roar);
            }

            // Stop Yeti movement and animation
            speed = 0;
            animator.SetFloat("Speed", 0);

            // Detach camera temporarily
            mainCamera.transform.parent = null;

            // Rotate skier sideways
            player.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);

            // Stop skier movement
            rb2d.gravityScale = 0;
            rb2d.linearVelocity = Vector2.zero;

            // Position skier above Yeti
            player.transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);

            // Reattach camera to skier
            mainCamera.transform.parent = player.transform;

            // Restart scene after short delay
            Invoke("RestartScene", 2f);
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
