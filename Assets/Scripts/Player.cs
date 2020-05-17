using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour {

	public float WalkSpeed = 3f;
	public float JumpForce = 5f;
	public float FlyingMovementSpeed = 3f;

	private MoveState movestate = MoveState.Idle;
	private Direction direction = Direction.Right;


	private Transform transform;
	private Rigidbody2D rigidbody;
	private Animator animator;

	private int JumpCounter = 0;
	private float WalkCounter = 0;
	private float WalkCouldown = 0.1f;
	private float SprintCounter = 0;
	private float SprintCouldown = 0.1f;


	public void MoveLeft(){
		if (movestate != MoveState.Jump) {
			
			movestate = MoveState.Move;
			if (direction == Direction.Right) {
				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				direction = Direction.Left;

			}

			WalkCounter = WalkCouldown;
			animator.Play ("Walk");	
		}else{
			if (direction == Direction.Right) {
				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				direction = Direction.Left;

				movestate = MoveState.Jump;


			}
			WalkCounter = WalkCouldown;
		} 
	}
	public void MoveRight(){
		if(movestate != MoveState.Jump){

			movestate = MoveState.Move;
			if(direction == Direction.Left){
				transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
				direction = Direction.Right;

			}

			WalkCounter = WalkCouldown;
			animator.Play("Walk");	
		}else{
			if (direction == Direction.Left) {
				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				direction = Direction.Right;

				movestate = MoveState.Jump;
			

			}
			WalkCounter = WalkCouldown;
		}  
	}
	public void Jump(){
		JumpCounter++;
	
			if (JumpCounter <= 1) {
				rigidbody.velocity = (Vector2.up * JumpForce * Time.deltaTime * 10);
				movestate = MoveState.Jump;


				animator.Play ("Jump");

			} else {
				if (rigidbody.velocity == Vector2.zero) {
					JumpCounter = 0;
					rigidbody.velocity = (Vector2.up * JumpForce * Time.deltaTime * 10);
					movestate = MoveState.Jump;
					

					animator.Play ("Jump");
				}
			}

	}
	public void Sprint(){
		movestate = MoveState.Sprint;
		animator.Play ("Sprint");
		SprintCounter = SprintCouldown;

	}

	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform>();
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (movestate);
		if (movestate == MoveState.Move) {
			
			rigidbody.velocity = ((direction == Direction.Left ? -Vector2.right : Vector2.right) * WalkSpeed * Time.deltaTime);

				


			WalkCounter -= Time.deltaTime;
			if (WalkCounter <= 0) {
				movestate = MoveState.Idle;
				animator.Play ("Idle");
			}
		} else if (movestate == MoveState.Jump) {
			

			WalkCounter -= Time.deltaTime;
			if (WalkCounter >= 0) {
				rigidbody.velocity += ((direction == Direction.Left ? -Vector2.right : Vector2.right) * WalkSpeed / 10 * Time.deltaTime);
			}
			if (rigidbody.velocity.y == 0) {
				
				WalkCounter = 0;
				movestate = MoveState.Idle;
				animator.Play ("Idle");

			}
		} else if (movestate == MoveState.Sprint) {
			rigidbody.velocity = ((direction == Direction.Left ? -Vector2.right : Vector2.right) * WalkSpeed*2 * Time.deltaTime);

			SprintCounter -= Time.deltaTime;
			if (SprintCounter <= 0) {
				movestate = MoveState.Idle;
				animator.Play ("Idle");
			}
		}
		
	}
	enum MoveState{
		Jump,
		Move,
		Sprint,
		Idle
	}
	enum Direction{
		Right,
		Left
	}

}
