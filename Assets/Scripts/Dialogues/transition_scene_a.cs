using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition_scene_a : MonoBehaviour
{
	public GameObject player;
	public Animator anim;
	public Animator anime;
	public GameObject ts;
	public AudioClip clip;

	void Update()
	{
		if(( player.transform.position[0] < 33) || (player.transform.position[0] > 42.7 && player.transform.position[0] < 47.5) || (player.transform.position[0] > 63 && player.transform.position[0] < 66.7) || (player.transform.position[0] > 77.8 && player.transform.position[0] < 82))
		{
			anim.SetBool("start", true);
			if (Input.GetButtonDown("Transition"))
			{
				ts.SetActive(false);
				GetComponent<AudioSource>().PlayOneShot(clip);
				 if (player.transform.position[0] > 42.7 && player.transform.position[0] < 47.5)
				{
					StartCoroutine(coLoadlevel(4));
				}
				else if (player.transform.position[0] > 63 && player.transform.position[0] < 66.7)
				{
					StartCoroutine(coLoadlevel(5));
				}
				else if (player.transform.position[0] > 77.8 && player.transform.position[0] < 82)
				{
					StartCoroutine(coLoadlevel(6));
				}
			}
		}
		else
		{
			anim.SetBool("start", false);
		}
		if (player.transform.position[0] > 94)
		{
			anime.SetBool("start", true);
			if (Input.GetButtonDown("Transition"))
			{
				GetComponent<AudioSource>().PlayOneShot(clip);
				StartCoroutine(coLoadlevel(7));
			}
		}
		else
		{
			anime.SetBool("start", false);
		}
	}

	IEnumerator coLoadlevel(int room)
	{
		yield return new WaitForSeconds(2.7f);
		SceneManager.LoadScene(room);
	}
}
