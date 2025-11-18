using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    // Allow speed changes in Inpsector
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get value of horizontal input
        float xInput = Input.GetAxis("Horizontal");

        // Get value of vertical input
        float yInput = Input.GetAxis("Vertical");

        // Move sprite using x and y coordinate input times speed and deltaTime
        transform.Translate(new Vector2(xInput, yInput) * speed * Time.deltaTime);
    }
}

/* REFLECTION QUESTIONS

   WRITE YOUR REFLECTION ANSWERS HERE:
   1. How does the Input Manager and this C# script work together to allow gameplay on different devices?


   2. Why do you think it's important for game designers and developers to understand the devices players are using to play their video games?


*/