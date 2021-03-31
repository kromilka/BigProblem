using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class trans : MonoBehaviour
{
	public AudioClip clip;
	public GameObject player;
	public Animator anim;
	public GameObject ts;
	public bool exit = false;

	void Update()
	{
		if (player.transform.position[0] < -5)
		{
			anim.SetBool("start", true);
			if (Input.GetButtonDown("Transition"))
			{
				exit = true;
				ts.SetActive(false);
				GetComponent<AudioSource>().PlayOneShot(clip);
				StartCoroutine(waitFor());
			}
		}
		else
		{
			anim.SetBool("start", false);
		}

	}
	IEnumerator waitFor()
	{
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene(2);
	}
}
