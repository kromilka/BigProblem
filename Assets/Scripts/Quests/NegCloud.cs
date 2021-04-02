using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegCloud : MonoBehaviour
{
    public Animator[] clouds;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Animator anim in clouds)
            {
                anim.SetTrigger("Shit");
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Animator anim in clouds)
            {
                anim.SetTrigger("Shit");
            }
        }
    }
}
