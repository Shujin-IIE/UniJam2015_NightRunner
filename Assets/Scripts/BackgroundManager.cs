using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour
{
	private GameObject Background;

	public void SetupBackground()
	{
		float offset = 0;
		Debug.Log ("chilcount = " + Background.transform.childCount.ToString());
		for (int i = 0; i<Background.transform.childCount; i++)
		{
			Background.transform.GetChild(i).Translate(new Vector3(-offset, 0, 0));
			offset += Background.transform.GetChild(i).gameObject.GetComponent<Renderer>().bounds.size.x;
			Debug.Log ("offset = " + offset.ToString());
		}
	}

	void Start ()
	{
		Background = Factory.Instance.GetObject(Factory.Elements.Background);
		Background.SetActive(true);
		SetupBackground();
		Background.transform.position = new Vector3(-20, 3, -27);
		//Background.GetComponent<SpriteRenderer>().receiveShadows = true;
	}

	void Update ()
	{
	
	}
}
