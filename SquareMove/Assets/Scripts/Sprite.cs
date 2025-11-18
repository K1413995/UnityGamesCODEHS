using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{
	public float speed = 2; // Default pixels per second
	
    // Start is called before the first frame update
    void Start()
    {
		// Print statement to the console at start of script
		Debug.Log("Hello Game World!");
    }

    // Update is called once per frame
    void Update()
    {
        // Get sprite's current position
        Vector2 position = transform.position;

        // Move sprite to the right at the specified speed
        position += Vector2.right * speed * Time.deltaTime;

        // Set sprite's new position
        transform.position = position;
    }
}