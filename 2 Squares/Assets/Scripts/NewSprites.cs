// For instructions, select EXAMPLE tab in the window to the right.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSprites : MonoBehaviour
{
    public GameObject square;
    
    public class Character
    {
        public float velocityX;
        public float velocityY;
        public SpriteRenderer spriteRenderer;
        public Vector2 position;
      
    }

    Character squareOne = new Character();
    Character squareTwo = new Character();

    void Start()
    {
        squareOne.position = new Vector2(4f, 0f);
        squareOne.velocityX = -0.5f;
        squareOne.velocityY = -1f;

        // Instantiate or clone the SquareOne GameObject
        GameObject SquareOne = Instantiate(square, squareOne.position, Quaternion.identity);
    
        // Add a SpriteRenderer component to the squareOne GameObject
        squareOne.spriteRenderer = SquareOne.GetComponent<SpriteRenderer>();
    
        // Set the sprite renderer color
        squareOne.spriteRenderer.color = Color.gray;

        SquareOne.GetComponent<Rigidbody2D>().linearVelocity = new Vector2 (squareOne.velocityX, squareOne.velocityY);

        squareTwo.position = new Vector2(-4f, 0f);
        squareTwo.velocityX = 1f;
        squareTwo.velocityY = 0.5f;

        // Instantiate or clone the SquareOne GameObject
        GameObject SquareTwo = Instantiate(square, squareTwo.position, Quaternion.identity);
    
        // Add a SpriteRenderer component to the squareOne GameObject
        squareTwo.spriteRenderer = SquareTwo.GetComponent<SpriteRenderer>();
    
        // Set the sprite renderer color
        squareTwo.spriteRenderer.color = Color.red;

        SquareTwo.GetComponent<Rigidbody2D>().linearVelocity = new Vector2 (squareTwo.velocityX, squareTwo.velocityY);
    }

    void Update()
    {
    
    }
}