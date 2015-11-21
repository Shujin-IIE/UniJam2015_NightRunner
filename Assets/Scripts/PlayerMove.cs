using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private enum Directions {Left, Right};

	private Directions CurrentDirection = Directions.Right;

	private Engine2D Engine;

	private float PivotToGround;

	private void Start ()
	{
		Engine = GetComponent<Engine2D>();
		if (Engine == null)
		{
			Debug.LogWarning("PlayerMove : Engine2D not found");
		}
		UserEvent.Instance.OnUserInputAxis += EventHandler;
		PivotToGround = (GetComponent<BoxCollider>().size.y)/2;
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
		}
	}

	private bool IsGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, PivotToGround + 0.5f);
	}


}
