using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour
{
	private GameObject Background;

	private float offset = 0f;

	public void SetupBackground()
	{
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

		Background = Factory.Instance.GetObject(Factory.Elements.Background);
		Background.SetActive(true);
		SetupBackground();
		Background.transform.position = new Vector3(-20+offset, 3, -27);

		offset = 0;
		float offsetY = -100;

		Background = Factory.Instance.GetObject(Factory.Elements.Background);
		Background.SetActive(true);
		SetupBackground();
		Background.transform.position = new Vector3(-20, 3-100, -27);
		
		Background = Factory.Instance.GetObject(Factory.Elements.Background);
		Background.SetActive(true);
		SetupBackground();
		Background.transform.position = new Vector3(-20+offset, 3-100, -27);
	}

	void Update ()
	{
	
	}
}
