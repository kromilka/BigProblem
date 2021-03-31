using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawn : MonoBehaviour
{
    public Animator anim;
    public GameObject plashka;
    public GameObject key;
    public bool isEnd = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("start", true);
            if (Input.GetButtonDown("LookFor"))
            {
                key.SetActive(true);
                isEnd = true;
                if (isEnd)
                {
                    plashka.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetBool("start", false);
            if(isEnd)
            {
                plashka.SetActive(false);
            }
        }
    }

}
