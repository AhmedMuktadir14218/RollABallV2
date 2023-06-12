using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro; /// Display the count value


public class PlayerController : MonoBehaviour
{
    // Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText; /// Display the count value
	public GameObject winTextObject; /// game end message

    private float movementX; /// Apply force to the Player
    private float movementY; /// Apply force to the Player

    private Rigidbody rb;
    private int count; /// Store the value of collected PickUps
    

    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>(); /// Apply input data to the Player
        
        // Set the count to zero
        count = 0; ///Store the value of collected PickUps

        SetCountText (); /// Display the count value

        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false); /// game end message
    }


    void FixedUpdate() /// Apply input data to the Player
    {
        // Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); /// Apply force to the Player

        rb.AddForce(movement * speed); /// Apply force to the Player
    }
    

    /// Disable PickUps with OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();

        }
    }


    /// OnMove function declaration.
    void OnMove(InputValue value)
    {
        /// function body.
        Vector2 v = value.Get<Vector2>(); /// Apply input data to the Player

        movementX = v.x; /// Apply force to the Player
        movementY = v.y; /// Apply force to the Player

    }


    /// Display the count value
    void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 12) 
		{
            // Set the text value of your 'winText'
            winTextObject.SetActive(true); /// game end message
		}
	}
    
}

