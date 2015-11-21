using UnityEngine;

public class Engine2D : MonoBehaviour
{
	[SerializeField]
	private float Speed = 10;

	[SerializeField]
	private float JumpHeigth = 0.5f;

	private Rigidbody Body;


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

	}

	public void Move(float hor, float ver)
	{
		transform.Translate(new Vector3(hor, 0, ver) * Speed * Time.deltaTime);
	}

	public void Jump()
	{
		Body.velocity = new Vector3(Body.velocity.x, Body.velocity.y + JumpHeigth, Body.velocity.z);
	}
}
