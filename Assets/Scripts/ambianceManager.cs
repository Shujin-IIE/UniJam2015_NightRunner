using UnityEngine;
using System.Collections;

public class ambianceManager : MonoBehaviour {

	[SerializeField]
	private GameObject player;
	[SerializeField]
	private GameObject whiteNoisePrefab;

	// Use this for initialization
	void Start () {
		//WhiteNoise noise = gameObject.AddComponent<WhiteNoise> ();
		//noise.Create(whiteNoisePrefab, player, 0.5f, 4f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
