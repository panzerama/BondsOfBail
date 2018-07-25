using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public int playerSpeedMagnitude = 10;
	public int playerJumpMagnitude = 10;

    private bool isFacingLeft = false;
	private float moveX;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update ()
	{
		MovePlayer();
	}

	void MovePlayer()
	{
		//controls
		
		moveX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown("Jump"))
		{
			Jump();
		}
		
		//animation
		
		//player direction

		if (moveX < 0.0f && !isFacingLeft)
		{
			FlipPlayer();
		}
		else if (moveX > 0.0f && isFacingLeft)
		{
			FlipPlayer();	//todo refactor, smells
		}
		
		//physics
		
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeedMagnitude,
			gameObject.GetComponent<Rigidbody2D>().velocity.y); //todo refactor smell
	}

	void Jump()
	{
		//jump code
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpMagnitude);
	}

	void FlipPlayer()
	{
		isFacingLeft = !isFacingLeft;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}
}

