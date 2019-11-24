using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {
	Collider objectCollider;
	Transform mainCamera;

	public float newXPosition = 0;
	public float newYPosition = 0;
	public float newZPosition = 0;
	// Use this for initialization
	void Start () {
		objectCollider = GetComponent<Collider> ();
		objectCollider.isTrigger = true;
		mainCamera = GameObject.FindWithTag("MainCamera").transform;
	}

	void OnTriggerEnter() {
		mainCamera.position = new Vector3 (newXPosition, newYPosition, newZPosition);
		print (String.Format("Moved camera to {0}, {1}, {2}", newXPosition,newYPosition, newZPosition));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
