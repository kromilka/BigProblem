using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transaaaction4 : MonoBehaviour
{
    public AudioClip clipt;
    public Animator anime;
	public bool ex = false;

    public void Awake()
    {
        anime.SetBool("start", false);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anime.SetBool("start", true);


            if (Input.GetButtonDown("Transition"))
            {
				ex = true;
                GetComponent<AudioSource>().PlayOneShot(clipt);
                StartCoroutine(wait());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anime.SetBool("start", false);
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(7);
    }
}