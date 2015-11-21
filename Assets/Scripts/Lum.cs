﻿using UnityEngine;
using System.Collections;

public class Lum : MonoBehaviour {
	
	[SerializeField]
	private GameObject lumExplodePrefab;

	private GameObject lumExplode;

	[SerializeField]
	public float velocityMax, xMax, yMax, xMin, yMin;

	private float x, y, time;



	void Start () {
		x = Random.Range(-velocityMax, velocityMax);
		y = Random.Range(-velocityMax, velocityMax);
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
			lumExplode = Instantiate (lumExplodePrefab,transform.localPosition, Quaternion.identity) as GameObject;
			Destroy (other.gameObject);
			Destroy (lumExplode.gameObject,1.0f);
		}
	}
}
