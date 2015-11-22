using UnityEngine;
using System.Collections;

public class LoadLvls : MonoBehaviour {

	public void LoadScene(int level){
		Application.LoadLevel (level);
	}

	public void ApplicationQuit(){
		Application.Quit ();
	}
}
