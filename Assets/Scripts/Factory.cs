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

	[SerializedField]
	private GameObject prefabFirefly;

	[SerializedFiled]
	private GameObject prefabBackground;


	private GameObject[] Prefabs = new GameObject[Elements.Length];

	private List<GameObject>[] ObjectList = new List<GameObject>[Elements.Length];

	private void Start()
	{
		for (int i = 0; i<Elements.Length; i++)
		{
			ObjectList[i] = new List<GameObject>();
		}
		//links between prefabs and enum
		Prefabs[Elements.Firefly] = prefabFirefly;
		Prefabs[Elements.Background] = prefabBackground;
	}

	public GameObject GetObject(Elements element)
	{
		List<GameObject> list = ObjectList[element];
		GameObject obj;
		if (list.Count > 0)
		{
			obj = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
		}
		else
		{
			obj = Instantiate(Prefabs[element], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			obj.SetActive(false);
		}
		return obj;
	}

	public void DisableObject(GameObject obj, Elements element)
	{
		List<GameObject> list = ObjectList[element];
		obj.SetActive(false);
		if (!list.Contains(obj))
		{
			list.Add(obj);
		}
	}

}
