using UnityEngine;
using System.Collections;

public class LightManager : MonoBehaviour {
	[SerializeField]
	private float intensityMax = 0;

	[SerializeField]
	private float deltaDiminishTime = 0;
	private float lastDiminish = 0;

	[SerializeField]
	private float diminishValue = 0;

	private Light light;

	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();

		if (light == null) {
			Debug.LogWarning("LightManager.Start(): light == null");
		}

		if (intensityMax < 0 || intensityMax > 8) {
			Debug.LogWarning("LightManager.Start(): intensityMax out of bound (intensityMax = " + intensityMax + " )");
		}

		light.intensity = intensityMax;
		lastDiminish = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		DiminishIntensityByTime();
	}

	void DiminishIntensityByTime () {
		if (lastDiminish + deltaDiminishTime < Time.time) {
			ModifyIntensity(-diminishValue);

			lastDiminish = Time.time;
			if (light.intensity <= 0) {
				GameManager.Instance.OnGameOver();
			}
		}
	}

	public void ModifyIntensity (float value) {
		light.intensity += value;
	}
}
