using UnityEngine;
using System.Collections;

// Receive and handle user events
public class InputManager : MonoBehaviour {
	// here to sign to the evnt from the UIMap
	private UserEvent userEvent;

	public delegate void Actions (KeyCode kc);
	public event Actions OnActions; 

	// Use this for initialization
	void Start () {
		userEvent = GameObject.Find("UIMap").GetComponent<UserEvent>();
		userEvent.OnUserInput += InputHandler;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void InputHandler (KeyCode kc) {
		// Need to do an special action? (look at kc)
		if (OnActions != null) {
			OnActions(kc);
		}
	}

	void OnCleanUp () {
		// no event
	}
}
