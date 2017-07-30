using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Vector3 velocity;
	public float speed = 200;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.AddForce(transform.forward * 500);
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		
	}

}
