using UnityEngine;
using System.Collections;

// Receive the events from the user
public class UserEvent : MonoBehaviour {
	
	public static UserEvent Instance
	{
		get;
		private set;
	}
	private void Awake()
	{
		if (Instance != null)
			return;
		Instance = this;
	}

	public delegate void UserInput (KeyCode kc);
	public event UserInput OnUserInput;

	public delegate void UserInputAxis (float hor, float ver);
	public event UserInputAxis OnUserInputAxis;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		userInputAxis();
	}

	void userInput () {
		if (OnUserInput != null) {
			// Replace the trigger by a gesture event
			if  (Input.GetKeyDown(KeyCode.LeftArrow)) {
				OnUserInput(KeyCode.LeftArrow);
			}
			if (Input.GetKeyDown(KeyCode.RightArrow)) {
				OnUserInput(KeyCode.RightArrow);
			}
		}
	}

	void userInputAxis () {
		if (OnUserInputAxis != null) {
			float hor = Input.GetAxis("Horizontal");
			float ver = Input.GetAxis("Vertical");
			if (hor != 0 || ver != 0)
			{
				OnUserInputAxis(hor, ver);
			}
		}
	}
}
