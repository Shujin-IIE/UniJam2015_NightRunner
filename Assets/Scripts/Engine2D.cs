using UnityEngine;

public class Engine2D : MonoBehaviour
{
	[SerializeField]
	private float Speed = 10;

	[SerializeField]
	private float JumpHeigth = 0.7f;

	private Rigidbody Body;

	bool Grounded = true;

	private PlayerMove playermove;

	private AudioSource audio;

	[SerializeField]
	private AudioClip run;

	private bool interuptorIsGrounded;

	private void Start()
	{
		Body = GetComponent<Rigidbody>();
		if (Body == null)
		{
			Debug.LogWarning("Engine2D : Rigidbody not found");
		}
		playermove = GetComponent<PlayerMove>();
		audio = GetComponent<AudioSource> ();
		interuptorIsGrounded = true;
	}

	private void Update()
	{
		if (Body.velocity.y == 0)
		{
			Debug.Log ("grounded = " + Grounded.ToString());
			if (interuptorIsGrounded == true){
				audio.Play();
				audio.loop = true;
				interuptorIsGrounded = false;
			}
			Grounded = true;
			playermove.animator.SetInteger("state", 0);
		}

		transform.Translate(new Vector3(1, 0, 0) * Speed * Time.deltaTime);
	}

	public void Move(float hor, float ver)
	{
		float velX = (hor != 0) ?  8*(hor/Mathf.Abs(hor)) : 0;

		if (GameManager.Instance.CurrentLevel == 1 || GameManager.Instance.CurrentLevel == 3) {
			velX = (velX > 0) ? 0 : velX;
		}
		else {
			velX = (velX < 0) ? 0 : velX;
		}
		Body.velocity = new Vector3(velX, Body.velocity.y, Body.velocity.z);
		transform.Translate(new Vector3(0, 0, ver) * Speed * Time.deltaTime);
	}

	public void Jump()
	{
		if (Grounded)
		{
//		Body.AddForce(new Vector3(0, JumpHeigth, 0), ForceMode.Impulse);
		Body.velocity = new Vector3(Body.velocity.x, JumpHeigth, Body.velocity.z);
		Grounded = false;
			audio.Stop();
			interuptorIsGrounded = true;
		}
	}

	public void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy") {
			Debug.Log("trig");
			Body.velocity = new Vector3(-8, Body.velocity.y, Body.velocity.z);
		}
	}
}
