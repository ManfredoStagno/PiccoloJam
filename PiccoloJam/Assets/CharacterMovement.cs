using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {


	//time and input delay Variables
	public float timer = 0;
	public float delay = 2f;
	public bool isPressed = false;
	public int timePressed;

	//movement and controller variables
	public float axis;
	public float moveForce = 250f;
	public float maxSpeed = 500f;
	public Rigidbody2D rb2d;


	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();

	}


	void Update () 
	{
		//check if any button is pressed
		if (Input.GetAxis ("Horizontal") !=0)
		{
			axis = Input.GetAxis ("Horizontal");
			Debug.Log ("press");
			isPressed = true;
			timePressed++;

		}
	}

	void FixedUpdate()
	{
		//if something was rpessed
		if (isPressed == true)
		{
			timer++;

			//if the time has passed
			if (timer >= 50*delay)
			{
				if (rb2d.velocity.x * axis < maxSpeed) 
				{
					rb2d.AddForce (Vector2.right * axis * moveForce);
				}

				Debug.Log (rb2d.velocity.x);
				Debug.Log("movement");
				timePressed--;

				//if the input has been processed
				if(timePressed <= 0)
					{
					isPressed = false;
					timePressed = 0;
					timer = 0;	
					}
			}
		}
	}
}
