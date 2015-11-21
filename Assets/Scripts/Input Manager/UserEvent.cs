using UnityEngine;
using System.Collections;

// Receive the events from the user
public class UserEvent : MonoBehaviour {

	public delegate void UserInput (KeyCode kc);
	public event UserInput OnUserInput;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		userInput();
	}

	void userInput () {
		if (OnUserInput != null) {
			// Replace the trigger by a gesture event
			if  (Input.GetKeyDown(KeyCode.LeftArrow)) {
				OnUserInput(KeyCode.LeftArrow);
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow)){
				OnUserInput(KeyCode.RightArrow);
			}
		}
	}
}
