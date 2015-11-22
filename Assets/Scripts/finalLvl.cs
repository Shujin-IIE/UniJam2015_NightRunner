using UnityEngine;
using System.Collections;

public class finalLvl : MonoBehaviour {


	void Start () {
	
	}

	void Update () {
		if (Input.anyKeyDown)
			Application.LoadLevel (0);
	}
}
