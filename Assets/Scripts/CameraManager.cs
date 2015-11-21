using UnityEngine;
using System.Collections;



public class CameraManager : MonoBehaviour {

	[SerializeField]
	private GameObject Player;

	[SerializeField]
	private float XOffset = 10;

	[SerializeField]
	private float YOffset = -10;

	[SerializeField]
	private float ZOffset = -10;



	void Start () 
	{
	
	}

	void Update () 
	{
		transform.position = new Vector3(Player.transform.position.x + XOffset, Player.transform.position.y + YOffset, Player.transform.position.z + ZOffset);
	}
}
