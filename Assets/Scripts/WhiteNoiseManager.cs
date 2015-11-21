using UnityEngine;
using System.Collections;

public class WhiteNoiseManager : MonoBehaviour {

	[SerializeField]
	private GameObject whiteNoiseObject;
	private SpriteRenderer whiteNoise;

	[SerializeField]
	private float duration;

	private float time;


	void Start () {
		time = 0.0f;
		whiteNoiseObject = Instantiate (whiteNoiseObject) as GameObject;
		whiteNoise = whiteNoiseObject.GetComponent<SpriteRenderer> ();
		whiteNoise.color = new Color (1f, 1f, 1f, 0.5f);
	}
	
	void Update () {
		whiteNoise.color = new Color (1f, 1f, 1f, 0.5f);
	}
}
