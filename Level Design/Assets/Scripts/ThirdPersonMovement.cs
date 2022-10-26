using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

	public CharacterController controller;
	public Transform cam;

	public float speed = 6f;
	public float turnSmoothTime = 0.1f;
	float turnSmoothVelocity;


	public float gravity = -9.81f;
	public float jumpHeight = 3f;

	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;

	Vector3 velocity;
	bool isGrounded;

	

	void Start()
	{
		//Cursor.lockState = CursorLockMode.Locked;
	}


	void Update()
	{
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f; //reset velocity accordingly 
		}


		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //dont wanna move it on y axis 

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
		if (direction.magnitude >= 0.1f)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			controller.Move(moveDir.normalized * speed * Time.deltaTime);

		}

		//if player is within radius 
			//if object is interactable 
				//set focus to interactable 
				//interact 
	}
}
