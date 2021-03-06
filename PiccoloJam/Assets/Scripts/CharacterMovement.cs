﻿

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour {
	
	public GameObject particle;
	new public GameObject camera;
	public Transform cameraTransform;

	public Animator anim;


	public AudioManager audioManager;
	private AudioSource audioSource;
	private Death death;
	//time and input delay Variables
	public float delay = 5f;
	List <float> haxis = new List<float>();
	List <float> vaxis = new List<float>();
	public float currentHAxis;
	public float currentVAxis;
	//movement and controller variables
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	private Rigidbody2D rb2d;
	//jump
	public bool grounded = false;
	public float jumpForce = 365f;
	public float maxJump = 10;
	//debug



	public void PlayOneShit(AudioClip clip)
	{	
		audioSource.clip = clip;
		audioSource.Play();
	}

	void spawnParticle()
	{
		Destroy (Instantiate (particle, cameraTransform), 3);
	}

	void Start()
	{
		
		rb2d = GetComponent<Rigidbody2D>();
		audioManager = GetComponent<AudioManager> ();
		anim = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource> ();
		death = GetComponent<Death> ();
		cameraTransform = camera.transform;

		for (int i = 0; i < delay*50; i++) 
		{
			haxis.Add (0);
			vaxis.Add (0);
		}

		anim.SetInteger ("transizione", 0);
	}


	void Update ()
	{
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) 
		{
			spawnParticle (); 
			PlayOneShit (audioManager.input);
		}


		if (grounded == false) 
		{
			anim.SetInteger ("transizione", 2);
		}
		else
		{if (Mathf.Abs (rb2d.velocity.x) > 0.1)
		{
				anim.SetInteger ("transizione", 1);
			}
		else
		{
			anim.SetInteger ("transizione", 0);
		}}
	}

	void FixedUpdate()
	{
		{
			haxis.Add(Input.GetAxisRaw("Horizontal"));
			
			//vaxis.Add(Input.GetAxis("Vertical"));
			//TODO if button is already pressed return 0, if button has just been pressed return 1

			if (Input.GetKey (KeyCode.UpArrow)) 
			{
				vaxis.Add (1);
			} 
			else
			{
				vaxis.Add (0);
			}



			currentHAxis = haxis [1];

				//movimento
				if (rb2d.velocity.x * currentHAxis < maxSpeed) 
					rb2d.AddForce (Vector2.right * currentHAxis * moveForce);

				if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
							rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
				//movimento

			haxis.RemoveAt(1);
		}
		if(grounded == true)
		{
			currentVAxis = vaxis [1];

			if (currentVAxis == 1)
				PlayOneShit (audioManager.output);

			//movimento
			if (rb2d.velocity.y * currentVAxis < maxSpeed) 
				rb2d.AddForce (Vector2.up * currentVAxis * jumpForce);
		

			if (rb2d.velocity.y > maxJump)
				rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Sign (rb2d.velocity.y) * maxJump);
			//movimento
		}
		vaxis.RemoveAt(1);
	}







	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag ("Ground")) 
		{
			grounded = true;
			PlayOneShit (audioManager.grounded);
		}


	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag ("Ground")) 
		{
			grounded = false;
		}
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.CompareTag ("InstantDeath")) 
		{
			death.InstaDeath();
			Debug.Log ("Collido");
		}

		if (coll.CompareTag("NextScene"))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
			
	}



}
