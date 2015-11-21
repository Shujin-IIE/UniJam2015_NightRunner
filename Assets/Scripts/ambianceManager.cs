using UnityEngine;
using System.Collections;

public class ambianceManager : MonoBehaviour {

	[SerializeField]
	private GameObject player;
	[SerializeField]
	private GameObject whiteNoisePrefab;
	[SerializeField]
	private float duration;

	public string zone;

	private AudioSource audioMusic;
	private AudioSource audioHeartBeat;

	void Start () {
		//WhiteNoise noise = gameObject.AddComponent<WhiteNoise> ();
		//noise.Create(whiteNoisePrefab, player, 0.5f, 4f);
		zone = "sage";
		audioMusic = GetComponents<AudioSource> ()[0];
		audioHeartBeat = GetComponents<AudioSource> () [1];

		//StartCoroutine("FadeIn",audio);
	}
	
	void Update () {
		if (zone == "sage") {
			FadeIn (audioMusic.volume, audioMusic, 0.7f);
		} 
		else if (zone == "stress") 
		{
			FadeOut (audioMusic.volume, audioMusic, 0.1f);
			FadeIn (audioHeartBeat.volume, audioHeartBeat, 1.0f);
		}
		else if (zone == "danger") 
		{

		}


	}

	void FadeIn(float volume, AudioSource audio, float volumeMax) {
		if (volume < volumeMax) {
			volume += 0.075f * Time.deltaTime;
			audio.volume = volume;
		}
		//return volume;
	}
	
	void FadeOut(float volume, AudioSource audio, float volumeMin) {
		if (volume > volumeMin) {
			volume -= 0.1f * Time.deltaTime;
			audio.volume = volume;
		}
		//return volume;
	}



	/*IEnumerator FadeIn(AudioSource audio) {
		if (audio.volume < 0.7f) {
			audio.volume += 0.075f * Time.deltaTime;
			yield return null;
		}
	}

	IEnumerator FadeOut(float volume, AudioSource audio) {
		if (volume > 0.1) {
			volume -= 0.1f * Time.deltaTime;
			audio.volume = volume;
			yield return null;
		}
		//return volume;
	}*/
}
