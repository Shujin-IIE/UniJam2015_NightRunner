using UnityEngine;
using System.Collections;

public class Lum : MonoBehaviour {
	
	[SerializeField]
	private GameObject lumExplodePrefab;

	private GameObject lumExplode;

	[SerializeField]
	public float velocityMax, xMax, yMax, xMin, yMin;

	private float x, y, time;

	[SerializeField]
	private AudioClip[] lumSounds;
	private float volume;
	
	private LightManager lm;
	[SerializeField]
	private float bonusValue;

	void Start () {
		x = Random.Range(-velocityMax, velocityMax);
		y = Random.Range(-velocityMax, velocityMax);
		xMax = transform.localPosition.x + xMax;
		yMax = transform.localPosition.y + yMax;
		xMin = transform.localPosition.x + xMin;
		yMin = transform.localPosition.y + yMin;

		volume = 1.0f;

		lm = GameObject.Find("Point light").GetComponent<LightManager>();
	}
	
	void Update () {
		
		time += Time.deltaTime;
		
		if (transform.localPosition.x > xMax) {
			x = Random.Range(-velocityMax, 0.0f);
			time = 0.0f; 
		}
		if (transform.localPosition.x < xMin) {
			x = Random.Range(0.0f, velocityMax);
			time = 0.0f; 
		}
		if (transform.localPosition.y > yMax) {
			y = Random.Range(-velocityMax, 0.0f);
			time = 0.0f; 
		}
		if (transform.localPosition.y < yMin) {
			y = Random.Range(0.0f, velocityMax);
			time = 0.0f;
		}

		if (time > 1.0f) {
			x = Random.Range(-velocityMax, velocityMax);
			y = Random.Range(-velocityMax, velocityMax);
			time = 0.0f;
		}
		
		transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y + y, transform.localPosition.z);
	}


	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			// Add bonus value
			lm.ModifyIntensity(bonusValue);

			// Gestion son
			AudioSource audio = GetComponent<AudioSource>();
			var lumSound = lumSounds[Random.Range(0,lumSounds.Length)];
			audio.clip = lumSound;
			audio.volume = volume;
			audio.Play();
			// Destruction objet
			lumExplode = Instantiate (lumExplodePrefab,transform.localPosition, Quaternion.identity) as GameObject;
			Destroy (gameObject.GetComponent<Renderer>());
			Destroy (gameObject.GetComponent<BoxCollider>());
			Destroy (lumExplode.gameObject,1.0f);
			Destroy (gameObject,1.0f);
		}
	}

	AudioClip getRandomLumSound(){
		return lumSounds [Random.Range (0, lumSounds.Length)];
	}
}
