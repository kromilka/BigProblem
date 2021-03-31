using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadRoom1 : MonoBehaviour
{
	public class Data
	{
		public string[] name;
		public Vector3[] tr;
		public bool openCh;
	}

	public GameObject shest;
	public string roomname;
	public GameObject klu;
	public GameObject otv;
	public GameObject chp;
	public GameObject lis;
	public GameObject ke;
	public GameObject itSpawn;
	public itemSpawn scrSp;
	public GameObject ex;
	public trans scrEx;
	public string js;
	public string temp;

	Data save = new Data();
	Data saved = new Data();

	void Awake()
	{
		if(roomname != "Room3")
		{
			scrSp = itSpawn.GetComponent<itemSpawn>();
		}
		scrEx = ex.GetComponent<trans>();
		/*loading*/
		if (PlayerPrefs.HasKey(roomname))
		{
			temp = PlayerPrefs.GetString(roomname);
			saved = JsonUtility.FromJson<Data>(temp);

			if (roomname != "Room3")
			{
				if (saved.openCh) { itSpawn.SetActive(false); scrSp.isEnd = true; }
			}


			foreach (GameObject i in GameObject.FindGameObjectsWithTag("quest"))
			{
				Destroy(i);
			}
			for (int i = 0; i < saved.tr.Length; i++)
			{
				if (saved.name[i].Contains("shest"))
				{
					Instantiate(shest, saved.tr[i], Quaternion.identity);
				}
				else if (saved.name[i].Contains("klu"))
				{
					Instantiate(klu, saved.tr[i], Quaternion.identity);
				}
				else if (saved.name[i].Contains("list"))
				{
					Instantiate(lis, saved.tr[i], Quaternion.identity);
				}
				else if (saved.name[i].Contains("otv"))
				{
					Instantiate(otv, saved.tr[i], Quaternion.identity);
				}
				else if (saved.name[i].Contains("key"))
				{
					Instantiate(ke, saved.tr[i], Quaternion.identity);
				}
				else if (saved.name[i].Contains("chip"))
				{
					Instantiate(chp, saved.tr[i], Quaternion.identity);
				}
			}
		}
	}

	void Update()
	{
		if (scrEx.exit)
		{
			/*saving*/

			if (roomname != "Room3")
			{
				save.openCh = scrSp.isEnd;//открывался ли шкаф
			}
			else
			{
				save.openCh = false;
			}

			List<string> name = new List<string>();
			List<Vector3> tr = new List<Vector3>();
			foreach (GameObject i in GameObject.FindGameObjectsWithTag("quest"))
			{
				name.Add(i.name);
				tr.Add(i.GetComponent<Transform>().position);
			}
			save.name = name.ToArray();
			save.tr = tr.ToArray();

			js = JsonUtility.ToJson(save);
			PlayerPrefs.SetString(roomname, js);
			PlayerPrefs.Save();
		}
	}
}