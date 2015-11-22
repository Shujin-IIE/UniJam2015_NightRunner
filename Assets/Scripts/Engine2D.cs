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


	private void Start()
	{
		Body = GetComponent<Rigidbody>();
		if (Body == null)
		{
			Debug.LogWarning("Engine2D : Rigidbody not found");
		}
		playermove = GetComponent<PlayerMove>();
	}

	private void Update()
	{
		if (Body.velocity.y == 0)
		{
//			Debug.Log ("grounded = " + Grounded.ToString());
			Grounded = true;
			playermove.animator.SetInteger("state", 0);
		}

		transform.Translate(new Vector3(1, 0, 0) * Speed * Time.deltaTime);
	}

	public void Move(float hor, float ver)
	{
		transform.Translate(new Vector3(0, 0, ver) * Speed * Time.deltaTime);
	}

	public void Jump()
	{
		if (Grounded)
		{
//		Body.AddForce(new Vector3(0, JumpHeigth, 0), ForceMode.Impulse);
		Body.velocity = new Vector3(Body.velocity.x, JumpHeigth, Body.velocity.z);
		Grounded = false;
		}
	}
}
