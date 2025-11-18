using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Determine whether or not the screen was touched
        if (Input.touchCount > 0)
        {
            // Get the values/coordinates of the first touch only (index 0)
            Touch touch = Input.GetTouch(0);

            // Create a Vector 2 variable that converts the screen's coordinates
            // to the game world's (Main Camera) coordinates
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            // Set the sprite's position to the same coordinates as the first screen touch
            transform.position = touchPosition;
        }
    }
}


/* REFLECTION QUESTIONS

   WRITE YOUR REFLECTION ANSWERS HERE:
   1. What other UI elements might be helpful to control game objects on a touchscreen device?
    buttons for direction or an emulated joystick to drag on screen, instead of just micelaneous tapping.

   2. Why didn't you need to make changes to the Input Manager in order to apply touchscreen input?
    Unity has prebuilt inputs for all devices or alternates keys.

*/