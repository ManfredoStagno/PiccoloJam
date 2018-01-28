using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public Sprite laser;
	Animator anim;
	private int t1 = 0;
	public int t2;


	// Use this for initialization
	void Start () {
		
		//anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		t1++;
		if (t1 >= t2) 
		{
			Debug.Log ("yes!wecand");
			anim = GetComponent<Animator> ();
			Animator.StringToHash ("lasergo");
			t1 = 0;
		} 

	}
		
}
