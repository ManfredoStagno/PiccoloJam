

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement1 : MonoBehaviour {


	//time and input delay Variables
	public float timer = 0;
	public float delay = 0.1f;
	public bool wasPressed = false;
	List <int[]> futMoves = new List<int[]>();

	//movement and controller variables
	public float axis;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public Rigidbody2D rb2d;


	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();

	}


	void Update () 
	{
	}

	void FixedUpdate()
	{
		//check if movemet button have been pressed
		if (Input.GetAxis ("Horizontal") !=0)
		{
			wasPressed = true;
		}

//		//if som movement buttons was pressed
		if (wasPressed == true)
		{
			timer++;
//
//			//if the time has passed
			if (timer >= 50*delay)
			{
//				//movimento
//				if (rb2d.velocity.x * axis < maxSpeed) 
//					rb2d.AddForce (Vector2.right * axis * moveForce);
//
//				if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
//							rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
//				//movimento



				Debug.Log("movement");


				//if the input has been processed

					{
					
					wasPressed = false;

					timer = 0;	
					}
			}
		}
	}
}
