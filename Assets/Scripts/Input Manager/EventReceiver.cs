using UnityEngine;
using System.Collections;

// Be affected byt the InputManager
public class EventReceiver : MonoBehaviour {

	[SerializeField]
	private GameObject userObject;
	private UserEvent userEvent;

	// Use this for initialization
	void Start () {
		userEvent = userObject.GetComponent<UserEvent>();
		userEvent.OnUserInput += EventHandler;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void EventHandler (KeyCode kc) {
		Debug.Log(kc);
	}
}
