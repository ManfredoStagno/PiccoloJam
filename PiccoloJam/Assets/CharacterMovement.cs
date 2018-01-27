

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {


	//time and input delay Variables
	public float delay = 5f;
	List <float> axis = new List<float>();

	//movement and controller variables

	public float currentAxis;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public Rigidbody2D rb2d;


	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();

		for (int i = 0; i < delay*50; i++) 
		{
			axis.Add (0);
		}

	}


	void Update () 
	{
		axis.Add(Input.GetAxisRaw("Horizontal"));
	}

	void FixedUpdate()
	{
		{
			currentAxis = axis [1];

				//movimento
				if (rb2d.velocity.x * currentAxis < maxSpeed) 
					rb2d.AddForce (Vector2.right * currentAxis * moveForce);

				if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
							rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
				//movimento

			axis.RemoveAt(1);


		}
	}
}
