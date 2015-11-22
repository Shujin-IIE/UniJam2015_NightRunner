using UnityEngine;
using System.Collections;

public class WhiteNoise : MonoBehaviour {

	private GameObject whiteNoisePrefab;
	private GameObject player;

	private SpriteRenderer whiteNoise;

	private float duration;
	private float time;
	private float opacity;

	private float xOffset;
	private float yOffset;
	private float zOffset;

	private AudioSource audio;
	private AudioClip glitch;

	void Start () {
		time = 0.0f;
		xOffset = 0.8f;
		yOffset = 2f;
		zOffset = -0.60f;
		whiteNoisePrefab = Instantiate (whiteNoisePrefab,new Vector3(xOffset,yOffset,zOffset),Quaternion.identity) as GameObject;
		whiteNoise = whiteNoisePrefab.GetComponent<SpriteRenderer> ();
		whiteNoise.color = new Color (1f, 1f, 1f, opacity);
		audio = GetComponent<AudioSource> ();
		audio.clip = glitch;
		audio.Play ();
	}
	
	void Update () {
		time += Time.deltaTime;
		whiteNoise.color = new Color (1f, 1f, 1f, opacity);
		whiteNoise.transform.position = new Vector3(player.transform.position.x + xOffset, yOffset, player.transform.position.z + zOffset);
		if (time > duration) {
			Destroy(gameObject.GetComponent<WhiteNoise>());
			Destroy (whiteNoisePrefab);
		}
	}

	public void Create(GameObject prefab,GameObject player, float opacity, float duration, AudioClip glitch){
		this.whiteNoisePrefab = prefab;
		this.player = player;
		this.opacity = opacity;
		this.duration = duration;
		this.glitch = glitch;
	}
}
