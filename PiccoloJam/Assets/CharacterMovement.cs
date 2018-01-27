

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {


	//time and input delay Variables

	public float delay = 5f;
	List <float> haxis = new List<float>();
	List <float> vaxis = new List<float>();

	//movement and controller variables
	public float currentHAxis;
	public float currentVAxis;

	public float moveForce = 365f;

	public float maxSpeed = 5f;
	private Rigidbody2D rb2d;

	//jump
	public Transform groundCheck;
	private bool grounded = false;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();

		for (int i = 0; i < delay*50; i++) 
		{
			haxis.Add (0);
			vaxis.Add (0);
		}
	}


	void Update () 
	{
		haxis.Add(Input.GetAxisRaw("Horizontal"));
		vaxis.Add(Input.GetAxisRaw("Vertical"));
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
	}

	void FixedUpdate()
	{
		{
			currentHAxis = haxis [1];

				//movimento
				if (rb2d.velocity.x * currentHAxis < maxSpeed) 
					rb2d.AddForce (Vector2.right * currentHAxis * moveForce);

				if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
							rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
				//movimento

			haxis.RemoveAt(1);
		}
		if(grounded==true)
		{
			currentVAxis = vaxis [1];

			//movimento
			if (rb2d.velocity.y * currentVAxis < maxSpeed) 
				rb2d.AddForce (Vector2.up * currentVAxis * moveForce);
			Debug.Log ("Jumping");

			if (rb2d.velocity.y > maxSpeed)
				rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Sign (rb2d.velocity.y) * maxSpeed);
			//movimento
			vaxis.RemoveAt(1);
			Debug.Log ("Bouncing");
		}
	}
}
