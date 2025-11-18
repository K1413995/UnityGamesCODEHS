using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColor : MonoBehaviour
{
	private Color newColor;
	private SpriteRenderer spriteRenderer;
	public bool isClicked = false;
	
	void OnMouseDown()
	{
		isClicked = true;
	}
	
    // Start is called before the first frame update
    void Start()
    {
		// Get the SpriteRenderer component from the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
		
		newColor = Color.white;
    }

    void Update()
    {
		if (isClicked){
			// Change the sprite's color to myColor
        	spriteRenderer.color = newColor;
		}
    }
}