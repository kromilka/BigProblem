	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.IO;

public class SaveLoad : MonoBehaviour
{
	public GameObject shest;
	public GameObject klu;
	public GameObject otv;
	public GameObject chp;
	public GameObject lis;
	public GameObject ke;


	public GameObject shest2;
	public GameObject klu2;
	public GameObject otv2;
	public GameObject chp2;


	public GameObject qCloud;

	public GameObject qCloud2;

	private GameObject player;
	public GameObject cam;
	public GameObject cam1;
	public GameObject cam2;
	public GameObject Bar;
	public GameObject t1;
	public GameObject t2;
	public GameObject t3;
	public GameObject t4;
	public GameObject t5;
	public GameObject SD;
	public GameObject robot;
	public GameObject GO1;
	public GameObject GO2;
	public DialogueAnimator D1;
	public DialogueAnimator D2;
	public Quest quest;
	public transaaaction tt1;
	public transaaaction1 tt2;
	public transaaaction2 tt3;
	public transaaaction3 tt4;
	public transaaaction4 tt5;
	public string js;
	public string temp;
	public Data saved;

	public class Data
	{
		public string[] namee; 
		public Vector3[] trr; 
		public bool firstd;
		public bool secondd;
		public Vector3 posPlayer;
		public int qN;
		public bool qw;
	}
	Data save = new Data();

	public void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		quest = robot.GetComponent<Quest>();

		if (PlayerPrefs.HasKey("Cabin")) {
			temp = PlayerPrefs.GetString("Cabin");
			saved = JsonUtility.FromJson<Data>(temp);

			player.GetComponent<Transform>().position = saved.posPlayer;
			quest.questNumber = saved.qN;

			D1.speak = saved.firstd;
			D2.speak = saved.secondd;

			if (saved.firstd) { Destroy(GO1); }
			if (saved.secondd) { Destroy(GO2); }
			if(saved.qN >= 3) { Destroy(Bar); }

			if(quest.questNumber < 3)
			{
				qCloud.transform.GetChild(0).gameObject.SetActive(true);
				qCloud.transform.GetChild(3).gameObject.SetActive(false);
				qCloud.transform.GetChild(2).gameObject.SetActive(false);
				qCloud.transform.GetChild(1).gameObject.SetActive(false);
				qCloud.transform.GetChild(4).gameObject.SetActive(false);

				// добавить то же самое но с qCloud2
			}
			else if(quest.questNumber < 5)
			{
				qCloud.transform.GetChild(0).gameObject.SetActive(false);
				qCloud.transform.GetChild(3).gameObject.SetActive(true);
				qCloud.transform.GetChild(2).gameObject.SetActive(false);
				qCloud.transform.GetChild(1).gameObject.SetActive(false);
				qCloud.transform.GetChild(4).gameObject.SetActive(false);
			}
			else if(quest.questNumber < 7)
			{
				qCloud.transform.GetChild(0).gameObject.SetActive(false);
				qCloud.transform.GetChild(3).gameObject.SetActive(false);
				qCloud.transform.GetChild(2).gameObject.SetActive(true);
				qCloud.transform.GetChild(1).gameObject.SetActive(false);
				qCloud.transform.GetChild(4).gameObject.SetActive(false);
			}
			else if(quest.questNumber < 10)
			{
				qCloud.transform.GetChild(0).gameObject.SetActive(false);
				qCloud.transform.GetChild(3).gameObject.SetActive(false);
				qCloud.transform.GetChild(2).gameObject.SetActive(false);
				qCloud.transform.GetChild(1).gameObject.SetActive(true);
				qCloud.transform.GetChild(4).gameObject.SetActive(false);
			}
			else if(quest.questNumber < 11)
			{
				qCloud.transform.GetChild(0).gameObject.SetActive(false);
				qCloud.transform.GetChild(3).gameObject.SetActive(false);
				qCloud.transform.GetChild(2).gameObject.SetActive(false);
				qCloud.transform.GetChild(1).gameObject.SetActive(false);
				qCloud.transform.GetChild(4).gameObject.SetActive(true);
			}

			foreach (GameObject i in GameObject.FindGameObjectsWithTag("quest"))
			{
				Destroy(i);
			}

			for(int i = 0; i < saved.trr.Length; i++)
			{
				if (saved.namee[i].Contains("shest"))
				{
					Instantiate(shest, saved.trr[i], Quaternion.identity);
				}
				else if(saved.namee[i].Contains("klu"))
				{
					Instantiate(klu, saved.trr[i], Quaternion.identity);
				}
				else if(saved.namee[i].Contains("list"))
				{
					Instantiate(lis, saved.trr[i], Quaternion.identity);
				}
				else if (saved.namee[i].Contains("otv"))
				{
					Instantiate(otv, saved.trr[i], Quaternion.identity);
				}
				else if (saved.namee[i].Contains("key"))
				{
					Instantiate(ke, saved.trr[i], Quaternion.identity);
				}
				else if (saved.namee[i].Contains("chip"))
				{
					Instantiate(chp, saved.trr[i], Quaternion.identity);
				}
			}
		}

		cam.GetComponent<CinemachineVirtualCamera>().Follow = player.GetComponent<Transform>();
		cam1.GetComponent<CinemachineVirtualCamera>().Follow = player.GetComponent<Transform>();
		cam2.GetComponent<CinemachineVirtualCamera>().Follow = player.GetComponent<Transform>();

		tt1 = t1.GetComponent<transaaaction>();
		tt2 = t2.GetComponent<transaaaction1>();
		tt3 = t3.GetComponent<transaaaction2>();
		tt4 = t4.GetComponent<transaaaction3>();
		tt5 = t5.GetComponent<transaaaction4>();
}
	
	public void Update()
	{
		if (tt1.ex || tt2.ex || tt3.ex || tt4.ex || tt5.ex)
		{
			List<string> name = new List<string>();
			List<Vector3> tr = new List<Vector3>();
			save.posPlayer = player.GetComponent<Transform>().position;
			save.qN = quest.questNumber;
			save.firstd = D1.speak;
			save.secondd = D2.speak;
			foreach(GameObject i in GameObject.FindGameObjectsWithTag("quest"))
			{
				name.Add(i.name);
				tr.Add(i.GetComponent<Transform>().position);
			}
			save.namee = name.ToArray();
			save.trr = tr.ToArray();
			js = JsonUtility.ToJson(save);
			PlayerPrefs.SetString("Cabin", js);
			PlayerPrefs.Save();
		}
	}

}
