using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour{

	private CharacterMovement characterMovement;
	private Animator anim;
	private float DeathTime;
	private bool died = false;
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		characterMovement = GetComponent<CharacterMovement> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time >= DeathTime + 3 && died == true ) 
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			Debug.Log ("carico scena");	
		}
	}

	public void InstaDeath ()

	{
		died = true;
		anim.Play("Death");
		characterMovement.PlayOneShit (characterMovement.audioManager.gameOver);
		Debug.Log ("morto");
		DeathTime = Time.time;
	}
}
