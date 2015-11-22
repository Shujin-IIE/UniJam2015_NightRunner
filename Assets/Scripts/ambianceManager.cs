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
	public int lvl;
	private AudioSource audioMusic;
	private AudioSource audioHeartBeat;

	public float temps;
	private float noiseDuration;
	[SerializeField]
	private AudioClip[] glitchs;

	public bool interuptor;

	void Start () {
		//WhiteNoise noise = gameObject.AddComponent<WhiteNoise> ();
		//noise.Create(whiteNoisePrefab, player, 0.5f, 4f);
		zone = "sage";
		lvl = 1;
		audioMusic = GetComponents<AudioSource> ()[0];
		audioHeartBeat = GetComponents<AudioSource> () [1];
		audioHeartBeat.loop = true;
		audioMusic.loop = true;
		temps = 0f;
		interuptor = true;
		//StartCoroutine("FadeIn",audio);
	}
	
	void Update () {
		//Debug.Log (temps);
		temps += Time.deltaTime;
		if (zone == "sage") {
			FadeIn (audioMusic.volume, audioMusic, 0.7f , 0.13f);
			FadeOut (audioHeartBeat.volume, audioHeartBeat, 0.0f, 0.2f);
		} 
		else if (zone == "stress") 
		{
			FadeOut (audioMusic.volume, audioMusic, 0.0f, 0.1f);
			FadeIn (audioHeartBeat.volume, audioHeartBeat, 1.0f, 0.13f);

			if (lvl == 1){

				glitch(3.0f,0);
				glitch(4.0f,3);
				glitch(6.0f,1);
				glitch(7.1f,2);
				glitch(7.9f,2);
			}
		}
		else if (zone == "danger") 
		{
			
		}
		/*if (Input.GetKeyDown("a")) {
			zone = "stress";
		}
		if (Input.GetKeyDown("b")) {
			zone = "stage";
		}
		if (Input.GetKeyDown("c")) {
			generateGlitch (1);
		}*/
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

	void glitch(float t1, int glitch){
		var t2 = t1 + 0.29f;
		if ( temps > t1 && interuptor && temps < t2) {
			interuptor = false;
			generateGlitch(glitch);
		}	
	}

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
