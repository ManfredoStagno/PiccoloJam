using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {


	public AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource> ();
	}


	public AudioClip input;//
	public AudioClip output;//
	public AudioClip transmission;
	public AudioClip endLevel;
	public AudioClip walk;
	public AudioClip jump;//
	public AudioClip grounded;//
	public AudioClip gameOver;   // 

	public AudioClip menu;

	//menu music
	//level music
}
