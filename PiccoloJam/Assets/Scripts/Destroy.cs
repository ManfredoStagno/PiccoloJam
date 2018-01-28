using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	public int t = 3;


	void Start ()
	{
		Destroy (gameObject, t);
	}

}
