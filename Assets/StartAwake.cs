using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartAwake : MonoBehaviour
{
	public Vector3 startpos;
	private GameObject player;
	public GameObject cam;
	public GameObject sc;

	public void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		player.GetComponent<Transform>().position = startpos;
		cam.GetComponent<CinemachineVirtualCamera>().Follow = player.GetComponent<Transform>();
		trans a = sc.GetComponent<trans>();
		a.player = player;
	}
}
