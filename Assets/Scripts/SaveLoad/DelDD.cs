using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelDD : MonoBehaviour
{
    void Awake()
	{
		foreach(GameObject i in GameObject.FindGameObjectsWithTag("Player"))
		{
			Destroy(i);
		}
		foreach (GameObject i in GameObject.FindGameObjectsWithTag("Invent"))
		{
			Destroy(i);
		}
	}
}
