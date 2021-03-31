using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class listtrigger : MonoBehaviour
{
    public Animator anim;
    public Animator Anime;
    private bool setAnime = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetBool("start", true);
            if(!setAnime && Input.GetButtonDown("Read"))
            {
                setAnime = true;
                Anime.SetBool("Trig", true);
            }
            else if(setAnime && Input.GetButtonDown("Read"))
            {
                Anime.SetBool("Trig",false);
                setAnime = false;
                StartCoroutine(waitTime());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("start",false);
            Anime.SetBool("Trig", false);
        }
    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(0.05f);
    }

}
