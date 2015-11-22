using UnityEngine;
using System.Collections;



public class CameraManager : MonoBehaviour {

	[SerializeField]
	private GameObject Player;

	// Camera offset init from the camera initial position
	public float XOffset;
	public float YOffset;
	private float ZOffset;
	
	void Start () 
	{
		XOffset = transform.position.x;
		YOffset = transform.position.y;
		ZOffset = transform.position.z;
	}

	void Update () 
	{
		transform.position = new Vector3(Player.transform.position.x + XOffset, Player.transform.position.y + YOffset, Player.transform.position.z + ZOffset);
	}
}
