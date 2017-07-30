using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float footSpeed;
	public float timeToReachTop;
	public float jumpHeight;
	public float distanceToPeak;

	[Header("Calculations")]
	public Vector3 moveDirection = Vector3.zero;
	public float initialJumpVelocity;
	public float initialMoveVelocity;
	public float gravity;
	public float moveGravity;

	[SerializeField] private CharacterController controller;
	[SerializeField] private ProjectileManager projectileManager;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		projectileManager = GetComponent<ProjectileManager>();


		gravity = -2 * jumpHeight / Mathf.Pow(timeToReachTop, 2);
		initialJumpVelocity = Mathf.Abs(gravity) * timeToReachTop;
		initialMoveVelocity = (2 * jumpHeight * footSpeed )/ distanceToPeak;
		moveGravity = -initialMoveVelocity * (footSpeed / distanceToPeak);		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0))
		{
			Shoot();
		}
		Move();
	}

	void FixedUpdate()
	{
		
	}

	void Shoot()
	{
		projectileManager.Shoot();
	}

	void Move()
	{
		if (controller.isGrounded)
		{
			if (Input.GetButtonDown("Jump")) 
				moveDirection.y = initialMoveVelocity; // keep the y velocity independent of the x velocity
		}
		else if (!controller.isGrounded)
		{
			moveDirection.y -= Mathf.Abs(moveGravity) * Time.deltaTime;  
		}
		moveDirection.x = Input.GetAxis("Horizontal") * footSpeed;
		moveDirection = transform.TransformDirection(moveDirection); // so even if it's a sphere rolling around
		controller.Move(moveDirection * Time.deltaTime);
	}

}
