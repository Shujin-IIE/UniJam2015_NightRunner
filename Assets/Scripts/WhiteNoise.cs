using UnityEngine;
using System.Collections;

public class WhiteNoise : MonoBehaviour {

	private GameObject whiteNoisePrefab;
	private GameObject player;

	private SpriteRenderer whiteNoise;

	private float duration;
	private float time;
	private float opacity;

	void Start () {
		time = 0.0f;
		whiteNoisePrefab = Instantiate (whiteNoisePrefab,new Vector3(0.8f,2f,-0.65f),Quaternion.identity) as GameObject;
		whiteNoise = whiteNoisePrefab.GetComponent<SpriteRenderer> ();
		whiteNoise.color = new Color (1f, 1f, 1f, opacity);
	}
	
	void Update () {
		time += Time.deltaTime;
		whiteNoise.color = new Color (1f, 1f, 1f, opacity);
		if (time > duration) {
			Destroy(gameObject.GetComponent<WhiteNoise>());
		}
	}

	public void Create(GameObject prefab,GameObject player, float opacity, float duration){
		this.whiteNoisePrefab = prefab;
		this.player = player;
		this.opacity = opacity;
		this.duration = duration;
	}
}
