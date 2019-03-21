using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;

	private Rigidbody _rb;

	// Use this for initialization
	void Start()
	{

		Cursor.lockState = CursorLockMode.Locked;
		_rb = gameObject.GetComponent<Rigidbody>();
	}
		
	// Update is called once per frame
	void Update () {

		Movement();
		
	}

	void Movement() {

		float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		Vector3 Move = new Vector3(moveX, 0, moveZ);
		_rb.velocity = Move * speed;

		}
}
