using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public GameObject st;
	public Animator anim;
	public DialogueManager dm;
	public Dialogue dialogue;
	public bool speak = false;

	public void OnTriggerStay2D(Collider2D other)
    {
		if (other.tag == "Player")
		{
			anim.SetBool("start", true);
			if (Input.GetButtonDown("Speak"))
			{
				speak = true;
				st.SetActive(false);
				FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
			}
		}
	}
    public void OnTriggerExit2D(Collider2D other)
    {
		anim.SetBool("start", false);
		dm.EndDialogue();
    }
}
