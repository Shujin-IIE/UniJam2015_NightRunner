using UnityEngine;
using System.Collections;

public class GameOverSoundManager : MonoBehaviour {
	
	private AudioSource audio;
	private float temps;
	
	void Start () {
		audio = GetComponent<AudioSource> ();
		audio.loop = true;
		temps = 0f;
	}
	
	void Update () {
		temps += Time.deltaTime;
		FadeIn (audio.volume, audio, 0.9f, 0.05f);
	}
	
	void FadeIn(float volume, AudioSource audio, float volumeMax , float speed) {
		if (volume < volumeMax) {
			volume += speed * Time.deltaTime;
			audio.volume = volume;
		}
	}
	
	void FadeOut(float volume, AudioSource audio, float volumeMin , float speed) {
		if (volume > volumeMin) {
			volume -= speed * Time.deltaTime;
			audio.volume = volume;
		}
	}
}
