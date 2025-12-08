using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;                  // <-- Added as required (TOP of API list)
using UnityEngine.UI;         // <-- Added at the bottom of API list

public class CollisionController : MonoBehaviour
{
    public bool changeColor;
    public Color myColor;

    public bool destroyEnemy;
    public bool destroyCollectibles;
    public float pushPower = 2.0f;

    public AudioClip collisionAudio;
    private AudioSource audioSource;

    // ============================
    // Score UI & Score Variables
    // ============================
    public TMP_Text scoreUI;        // <-- Added
    public int increaseScore = 1;   // <-- Added
    public int decreaseScore = 1;   // <-- Added
    private int score = 0;          // <-- Added


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // ============================
    // Update Score UI Every Frame
    // ============================
    void Update()
    {
        if (scoreUI != null)
        {
            scoreUI.text = "Score: "+ score.ToString();
        }
    }

    // only for GameObjects with a mesh, box, or other collider except for character controller and wheel colliders
    void OnCollisionEnter(Collision other)
    {
        if (changeColor == true)
        {
            gameObject.GetComponent<Renderer>().material.color = myColor;
        }

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(collisionAudio, 0.5F);
        }

        if (destroyEnemy == true && other.gameObject.tag == "Enemy" ||
            destroyCollectibles == true && other.gameObject.tag == "Collectible")
        {
            Destroy(other.gameObject);
        }

        // ============================
        // SCORE INCREASE / DECREASE
        // ============================

        // Increase score for Collectibles
        if (scoreUI != null && other.gameObject.tag == "Collectible")
        {
            score += increaseScore;
        }

        // Decrease score for Enemies
        if (scoreUI != null && other.gameObject.tag == "Enemy")
        {
            score -= decreaseScore;
        }
    }

    // only for GameObjects with a character controller applied
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // If no Rigidbody or is Kinematic, do nothing
        if (body == null || body.isKinematic)
        {
            return;
        }

        // Don't push ground or platform GameObjects below character
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        // Calculate push direction from move direction, only along x and z axes - no vertical pushing
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // Apply pushing force if tagged "Object"
        if (hit.gameObject.tag == "Object")
        {
            body.linearVelocity = pushDir * pushPower;
        }

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(collisionAudio, 0.5F);
        }

        if (destroyEnemy == true && hit.gameObject.tag == "Enemy" ||
            destroyCollectibles == true && hit.gameObject.tag == "Collectible")
        {
            Destroy(hit.gameObject);
        }

        // ============================
        // SCORE INCREASE / DECREASE
        // ============================

        // Increase score for Collectibles
        if (scoreUI != null && hit.gameObject.tag == "Collectible")
        {
            score += increaseScore;
        }

        // Decrease score for Enemies
        if (scoreUI != null && hit.gameObject.tag == "Enemy")
        {
            score -= decreaseScore;
        }
    }
}
