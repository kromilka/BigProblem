using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearData : MonoBehaviour
{
    void Awake()
	{
		PlayerPrefs.DeleteAll();
	}
}
