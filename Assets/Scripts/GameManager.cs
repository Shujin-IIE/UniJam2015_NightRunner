using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private int CurrentLevel;

	private bool LeftToRight = true;

	private bool StressMode = false;

	private bool ClimaxMode = false;

	[SerializeField]
	private GameObject Player;

	[SerializeField]
	private GameObject Spawn1;
	[SerializeField]
	private GameObject Spawn2;
	[SerializeField]
	private GameObject Spawn3;

	[SerializeField]
	private GameObject Stress;
	[SerializeField]
	private GameObject Stress2;

	[SerializeField]
	private GameObject Climax;
	[SerializeField]
	private GameObject Climax2;

	[SerializeField]
	private GameObject Death;
	[SerializeField]
	private GameObject Death2;

	[SerializeField]
	private GameObject Camera;


	
	void Start () 
	{
		CurrentLevel = 1;
		Player.transform.position = Spawn1.transform.position;
	}

	void Update ()
	{
		CheckForGameOver();
		if(!StressMode && !ClimaxMode)
		{
			if (LeftToRight)
			{
				if (Player.transform.position.x > Stress.transform.position.x)
				{
					OnStressMode();
				}
			}
			else
			{
				if (Player.transform.position.x < Stress2.transform.position.x)
				{
					OnStressMode();
				}
			}
		}
		else if (StressMode)
		{
			if (LeftToRight)
			{
				if (Player.transform.position.x > Climax.transform.position.x)
				{
					OnClimaxMode();
				}
			}
			else
			{
				if (Player.transform.position.x > Climax2.transform.position.x)
				{
					OnClimaxMode();
				}

			}
		}
		else if (ClimaxMode)
		{
			if (LeftToRight)
			{
				if (Player.transform.position.x > Death.transform.position.x)
				{
					OnGameOver();
				}
				else if (Input.GetKey(KeyCode.LeftArrow))
				{
					OnNormalMode(CurrentLevel+1);
				}
			}
			else
			{
				if (Player.transform.position.x < Death2.transform.position.x)
				{
					OnGameOver();
				}
				else if (Input.GetKey(KeyCode.RightArrow))
				{
					OnNormalMode(CurrentLevel+1);
				}
			}
		}
	}

	private void OnStressMode()
	{
		Debug.Log ("Switch to stress mode");
		StressMode = true;
		ClimaxMode = false;

		Camera.GetComponent<ambianceManager>().zone = "stress";
	}

	private void OnClimaxMode()
	{
		Debug.Log ("Switch to climax mode");
		StressMode = false;
		ClimaxMode = true;

		Camera.GetComponent<ambianceManager>().zone = "danger";
	}

	private void OnNormalMode(int lvl)
	{
		Debug.Log ("Switch to normal mode for lvl " + lvl.ToString());
		StressMode = false;
		Camera.GetComponent<CameraManager>().YOffset -= 100;
		ClimaxMode = false;
		CurrentLevel = lvl;
		if (lvl == 1)
		{
			Player.transform.position = Spawn1.transform.position;
			LeftToRight = true;
		}
		else if (lvl == 2)
		{
			Player.transform.position = Spawn2.transform.position;
			LeftToRight = false;
		}
		else
		{
			Player.transform.position = Spawn3.transform.position;
			LeftToRight = true;
		}

		Camera.GetComponent<ambianceManager>().zone = "calme";
	}

	private void OnGameOver()
	{
		Debug.Log ("Game Over !");
	}

	private void CheckForGameOver()
	{
		if (CurrentLevel == 1 && Player.transform.position.y < -10)
		{
			OnGameOver();
		}
		else if (CurrentLevel == 2 && Player.transform.position.y < -110)
		{
			OnGameOver();
		}
		if (CurrentLevel == 3 && Player.transform.position.y < -210)
		{
			OnGameOver();
		}
	}
}
