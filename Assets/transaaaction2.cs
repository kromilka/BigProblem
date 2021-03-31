using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transaaaction2 : MonoBehaviour
{
    public AudioClip clip;
    public Animator anim;
	public bool ex = false;

    public void Awake()
    {
        anim.SetBool("start", false);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("start", true);
            Debug.Log("AAA");

            if (Input.GetButtonDown("Transition"))
            {
				ex = true;
                GetComponent<AudioSource>().PlayOneShot(clip);
                StartCoroutine(waitFor());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("start", false);
        }
    }
    IEnumerator waitFor()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(5);
    }
}
