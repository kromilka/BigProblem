using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class transmeh : MonoBehaviour

{
    public GameObject momk;
	public GameObject momt;
	public GameObject kidt;

	void Update()
    {
        if (!momk.activeSelf && !momt.activeSelf && !kidt.activeSelf)
        {
            SceneManager.LoadScene(2);
        }
    }
}