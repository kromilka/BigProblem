using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiosystem : MonoBehaviour
{
	public AudioClip Birds;
	public AudioClip Corridor;
	public GameObject player;
	private bool flag_first = true;
	private bool flag_second = true;

	// Update is called once per frame
	void Update()
	{
		if(player.transform.position[0] < 24)
		{
			if (flag_first)
			{
				if (!flag_second)
				{
					GetComponent<AudioSource>().Stop();
				}
				GetComponent<AudioSource>().PlayOneShot(Birds);
				flag_first = false;
				flag_second = true;
			}
		}
		else
		{
			if (flag_second)
			{
				if (!flag_first)
				{
					GetComponent<AudioSource>().Stop();
				}
				GetComponent<AudioSource>().PlayOneShot(Corridor);
				flag_second = false;
				flag_first = true;
			}
		}
	}
}
