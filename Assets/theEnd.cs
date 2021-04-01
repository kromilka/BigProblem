using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class theEnd : MonoBehaviour
{
    public Animator stanim;
    public GameObject start;
    public Animator anim;
    public Animator anime;
    public AudioClip clip;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            stanim.SetBool("start", true);
            if(Input.GetButtonDown("End"))
            {
                anim.SetTrigger("Trig");
                anime.SetTrigger("Trig");
                GetComponent<AudioSource>().PlayOneShot(clip);
                start.SetActive(false);
                StartCoroutine(waitFor());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            stanim.SetBool("start", false);
        }
    }

   IEnumerator waitFor()
    {
        yield return new WaitForSeconds(7.7f);
        SceneManager.LoadScene(8);
    }
}
