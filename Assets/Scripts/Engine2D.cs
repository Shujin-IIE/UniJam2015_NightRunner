using UnityEngine;

public class Engine2D : MonoBehaviour
{
	[SerializeField]
	private float Speed = 10;

	[SerializeField]
	private float JumpHeigth = 0.7f;

	private Rigidbody Body;

	bool Grounded = true;


	private void Start()
	{
		Body = GetComponent<Rigidbody>();
		if (Body == null)
		{
			Debug.LogWarning("Engine2D : Rigidbody not found");
		}
	}

	private void Update()
	{
		if (Body.velocity.y == 0)
		{
			Debug.Log ("grounded = " + Grounded.ToString());
			Grounded = true;
			
		}
	}

	public void Move(float hor, float ver)
	{
		transform.Translate(new Vector3(hor, 0, ver) * Speed * Time.deltaTime);
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
