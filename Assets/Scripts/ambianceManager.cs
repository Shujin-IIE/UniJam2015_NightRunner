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

	private float temps;
	private float noiseDuration;
	[SerializeField]
	private AudioClip[] glitchs;

	void Start () {
		//WhiteNoise noise = gameObject.AddComponent<WhiteNoise> ();
		//noise.Create(whiteNoisePrefab, player, 0.5f, 4f);
		zone = "sage";
		audioMusic = GetComponents<AudioSource> ()[0];
		audioHeartBeat = GetComponents<AudioSource> () [1];
		temps = 0f;
		//StartCoroutine("FadeIn",audio);
	}
	
	void Update () {
		temps += Time.deltaTime;
		if (zone == "sage") {
			FadeIn (audioMusic.volume, audioMusic, 0.7f , 0.13f);
			FadeOut (audioHeartBeat.volume, audioHeartBeat, 0.0f, 0.2f);
		} 
		else if (zone == "stress") 
		{
			FadeOut (audioMusic.volume, audioMusic, 0.0f, 0.1f);
			FadeIn (audioHeartBeat.volume, audioHeartBeat, 1.0f, 0.13f);
		}
		else if (zone == "danger") 
		{
			
		}
		if (Input.GetKeyDown("a")) {
			zone = "stress";
		}
		if (Input.GetKeyDown("b")) {
			zone = "stage";
		}
		if (Input.GetKeyDown("c")) {
			generateGlitch (2);
		}
	}
	
	void FadeIn(float volume, AudioSource audio, float volumeMax , float speed) {
		if (volume < volumeMax) {
			volume += speed * Time.deltaTime;
			audio.volume = volume;
		}
		//return volume;
	}
	
	void FadeOut(float volume, AudioSource audio, float volumeMin , float speed) {
		if (volume > volumeMin) {
			volume -= speed * Time.deltaTime;
			audio.volume = volume;
		}
		//return volume;
	}


	float random(float min, float max){
		return (Random.value * max - min) + min;
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

	void generateGlitch(int prefab){
		switch (prefab) 
		{
		case 0 : 
			WhiteNoise noiseP1 = gameObject.AddComponent<WhiteNoise> ();
			noiseP1.Create(whiteNoisePrefab, player, 0.4f, 0.70f, glitchs[0]);
			break;
		case 1 :
			WhiteNoise noiseP2 = gameObject.AddComponent<WhiteNoise> ();
			noiseP2.Create(whiteNoisePrefab, player, 0.35f, 0.75f, glitchs[1]);
			break;
		case 2 :
			WhiteNoise noiseP3 = gameObject.AddComponent<WhiteNoise> ();
			noiseP3.Create(whiteNoisePrefab, player, 0.8f, 0.3f, glitchs[2]);
			break;
		case 3:
			WhiteNoise noiseP4 = gameObject.AddComponent<WhiteNoise> ();
			noiseP4.Create(whiteNoisePrefab, player, 0.2f, 1.7f, glitchs[3]);
			break;
		}
	}

}
