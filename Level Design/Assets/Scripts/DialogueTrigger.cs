using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;

    private void Update()
    {
        Debug.Log("In DialogueTrigger");
    }

    public void TriggerDialogue()
	{
		FindObjectOfType<DialogueUI>().StartDialogue(dialogue);
	}
}
