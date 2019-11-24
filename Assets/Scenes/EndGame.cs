using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {
	Collider objectCollider;
	Transform endTransform;

	public float posX1 = 0f;
	public float posZ1 = 0f;
	public float posX2 = 0f;
	public float posZ2 = 0f;
	public float posX3 = 0f;
	public float posZ3 = 0f;
	// Use this for initialization
	void Start () {
		objectCollider = GetComponent<Collider> ();
		objectCollider.isTrigger = true;
		endTransform = gameObject.transform;

		int randomPosition = Random.Range (0, 3);
		switch (randomPosition) {
		case 0:
			endTransform.position = new Vector3 (posX1, 0.6f, posZ1);
			break;
		case 1:
			endTransform.position = new Vector3 (posX2, 0.6f, posZ2);
			break;
		case 2:
			endTransform.position = new Vector3 (posX3, 0.6f, posZ3);
			break;
		}
	}

	void OnTriggerEnter() {
		print ("quitting");
		Application.Quit ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			print ("quitting");
			Application.Quit ();
		}
	}
}
