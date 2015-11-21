using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/*
 * To add a new object to the factory :
 * Add it to the enum,
 * Create an attribute for the prefab
 * In start, link prefab and enum
 */

public class Factory : MonoBehaviour 
{
	//Object types that need to be stored in the factory
	public enum Elements {Firefly, Background, Length /*length of the enum*/};

	[SerializeField]
	private GameObject prefabFirefly;

	[SerializeField]
	private GameObject prefabBackground;


	private GameObject[] Prefabs = new GameObject[(int) Elements.Length];

	private List<GameObject>[] ObjectList = new List<GameObject>[(int) Elements.Length];

	private void Start()
	{
		for (int i = 0; i<(int)Elements.Length; i++)
		{
			ObjectList[i] = new List<GameObject>();
		}
		//links between prefabs and enum
		Prefabs[(int) Elements.Firefly] = prefabFirefly;
		Prefabs[(int) Elements.Background] = prefabBackground;
	}

	public GameObject GetObject(Elements element)
	{
		List<GameObject> list = ObjectList[(int) element];
		GameObject obj;
		if (list.Count > 0)
		{
			obj = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
		}
		else
		{
			obj = Instantiate(Prefabs[(int) element], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			obj.SetActive(false);
		}
		return obj;
	}

	public void DisableObject(GameObject obj, Elements element)
	{
		List<GameObject> list = ObjectList[(int) element];
		obj.SetActive(false);
		if (!list.Contains(obj))
		{
			list.Add(obj);
		}
	}

}
