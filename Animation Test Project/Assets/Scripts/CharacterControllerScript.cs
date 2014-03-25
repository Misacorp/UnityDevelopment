using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {

	public float maxSpeed = 10;
	public float jumpForce = 700f;
	bool facingRight = true;

	Animator anim;
	
	//	Jumping
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.02f;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius,whatIsGround);
		anim.SetBool ("ground", grounded);
		anim.SetFloat ("vSpeed",rigidbody2D.velocity.y);

		float move = Input.GetAxis("Horizontal");
		anim.SetFloat ("speed", Mathf.Abs (move));
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		if(move > 0 && !facingRight)	{
			Flip ();
		}
		else if(move < 0 && facingRight) {
			Flip ();
		}


	}

	void Update() {
		if(grounded && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("ground", false);
			rigidbody2D.AddForce (new Vector2(0, jumpForce));
		}

		if(Input.GetKeyDown (KeyCode.LeftControl))  {
			anim.SetTrigger("punch");
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
