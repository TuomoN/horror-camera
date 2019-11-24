using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	CharacterController controller;
	Camera mainCamera;

	public float speed = 5.0f;

	private Vector3 moveDirection = Vector3.zero;
	private float oldHorizontal = 0f;
	private float oldVertical = 0f;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		// If input changes, recalculate movement direction
		if (Input.GetAxis ("Horizontal") != oldHorizontal || Input.GetAxis ("Vertical") != oldVertical) {
			oldHorizontal = Input.GetAxis ("Horizontal");
			oldVertical = Input.GetAxis ("Vertical");
			if (mainCamera != null) {
				Vector3 cameraForward = mainCamera.transform.TransformDirection (Vector3.forward);
				cameraForward.y = 0;
				cameraForward = cameraForward.normalized;
				Vector3 cameraSide = new Vector3 (cameraForward.z, 0, -cameraForward.x);
				moveDirection = Input.GetAxis ("Horizontal") * cameraSide + Input.GetAxis ("Vertical") * cameraForward;
			}
			else moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical"));
		}

		controller.Move(moveDirection * speed * Time.deltaTime);
		if (moveDirection != Vector3.zero) transform.rotation = Quaternion.LookRotation (moveDirection, Vector3.up);
	}
}
