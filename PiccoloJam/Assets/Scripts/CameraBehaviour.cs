﻿using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	Transform player;

	[SerializeField]
	float z_offset = -10f;
	[SerializeField]
	float y_offset = 3f;

	public float x_offset = 3f;

	[SerializeField]
	float smooth = 0.3f;


	Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	// Update is called once per frame
	void Update () {
		if (player != null) {

			Vector3 targetPosition = new Vector3 (player.position.x + x_offset, 0, player.position.z + z_offset);
			transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref velocity, smooth);
		}
	}
}
