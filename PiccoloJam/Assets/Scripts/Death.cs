using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour{

	private Animator anim;
	private float DeathTime;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time >= DeathTime + 3) 
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				}
	}

	public void InstaDeath ()

	{
		anim.Play("Death"); 
		DeathTime = Time.time;
	}
}
