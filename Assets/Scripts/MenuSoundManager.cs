using UnityEngine;
using System.Collections;

public class MenuSoundManager : MonoBehaviour {

	private AudioSource audio;
	private AudioSource audio2;
	private float temps;
	private GameObject start;

	void Start () {
		audio = GetComponents<AudioSource> ()[0];
		audio2 = GetComponents<AudioSource> ()[1];
		audio.loop = true;
		temps = 0f;
	}
	
	void Update () {
		temps += Time.deltaTime;
		FadeIn (audio.volume, audio, 0.9f, 0.05f);
		start = GameObject.Find ("jouer");
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
