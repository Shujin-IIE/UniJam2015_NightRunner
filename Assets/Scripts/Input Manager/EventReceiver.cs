using UnityEngine;
using System.Collections;

// Be affected byt the InputManager
public class EventReceiver : MonoBehaviour {

	private InputManager inputManager;

	// Use this for initialization
	void Start () {
		inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
		inputManager.OnActions += EventHandler;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void EventHandler (KeyCode kc) {
		Debug.Log(kc);
	}
}
