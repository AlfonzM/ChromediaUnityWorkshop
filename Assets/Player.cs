using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int playerNo;

	public GameObject bullet;
	public float jumpForce;

	// move stuff
	public float speed;
	enum Direction { left, right };
	Direction dir;
	Animator anim;
	Vector3 startPos;

	// jump stuff
	Vector3 position;
	Rigidbody2D rigidbody;
	bool canJump;

	// shoot stuff
	float attackDelay = 0.2f;
	bool canAttack;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		canJump = true;
		canAttack = true;

		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Controls ();

		anim.SetFloat ("xspeed", Mathf.Abs (rigidbody.velocity.x));
	}

	void Controls(){
		MovementControls ();

		if(Input.GetAxisRaw("JumpP" + playerNo) > 0 && canJump){
			Jump();
		}
		
		if(Input.GetAxisRaw("FireP" + playerNo) > 0){
			if(canAttack){
				Fire();
			}
		}
	}

	void MovementControls(){
		if (Input.GetAxis("HorizontalP" + playerNo) < 0)
		{	
			rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
			dir = Direction.left;
			transform.localScale = new Vector3(-1,1,1);
		} 
		else if (Input.GetAxis("HorizontalP" + playerNo) > 0)
		{
			rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
			transform.localScale = new Vector3(1,1,1);
			dir = Direction.right;
		}
		else{
			rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
		}
	}

	void Fire(){
		GameObject go = Instantiate (bullet, transform.position, Quaternion.identity) as GameObject;
		if (dir == Direction.left) {
			go.transform.Rotate(new Vector3(0,180,0));
		}

		canAttack = false;
		Invoke ("EnableAttack", attackDelay);
	}

	void EnableAttack(){
		canAttack = true;
	}

	void Jump(){
		// play sound
		// display jump animation
		// other jump stuff
		rigidbody.velocity = new Vector2 (rigidbody.velocity.x, 0);
		rigidbody.AddForce(new Vector2(0, jumpForce));

		canJump = false;
	}

	public void Hit(){
		gameObject.SetActive (false);
		Invoke ("Respawn", 1);
	}

	void Respawn(){
		transform.position = startPos;
		gameObject.SetActive (true);
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Ground") {
			canJump = true;
		}
	}
}