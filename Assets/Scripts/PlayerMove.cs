using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private enum Directions {Left, Right};

	private Directions CurrentDirection = Directions.Right;

	private Engine2D Engine;

	private float PivotToGround;

	private AudioSource audio;

	public Animator animator;

	[SerializeField]
	private AudioClip jumpSound;
	[SerializeField]
	private AudioClip runLoop;

	public bool isGrounded = true;

//	public float threshold = 0.3f;

	private void Start ()
	{
		Engine = GetComponent<Engine2D>();
		if (Engine == null)
		{
			Debug.LogWarning("PlayerMove : Engine2D not found");
		}
		UserEvent.Instance.OnUserInputAxis += EventHandler;
		PivotToGround = (GetComponent<BoxCollider>().size.y)/2;

		animator = GetComponent<Animator>();

		/*var audio = GetComponent<AudioSource> ();
		audio.clip = runLoop;
		audio.loop = true;
		audio.Play ();*/
	}

	private void Update ()
	{

	}

	private void EventHandler(float hor, float ver)
	{
		Engine.Move(hor, 0);
		if (ver > 0 && IsGrounded())
		{
			Engine.Jump();
			animator.SetInteger("state", 1);
		}
	}

	void OnCollisionrEnter (Collider other) {
		if (other.CompareTag ("Stage1") || other.CompareTag("Stage2") || other.CompareTag("Stage3")) {
			isGrounded = true;
		}
	}

	void OnCollisionExit () {
		isGrounded = false;
	}

	private bool IsGrounded()
	{
//		Debug.Log ("isGrounded: " + isGrounded);
//		return isGrounded;
//		return transform.position.y < threshold;
		return Physics.Raycast(transform.position, -Vector3.up, PivotToGround + 0.5f);
	}


}
