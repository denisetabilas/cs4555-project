using System.Collections; //for queue
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for updating UI 

public class DialogueUI : MonoBehaviour
{

	public Text nameText;
	public Text dialogueText;

	//public Animator animator;


	private Queue<string> sentences;
	void Start()
	{
		sentences = new Queue<string>();
	}

	

	public void StartDialogue(Dialogue dialogue)
	{
		Debug.Log("starting dialogue");
		//animator.SetBool("IsOpen", true);

		Debug.Log("Starting convo with " + dialogue.name); //testing

		nameText.text = dialogue.name;

		//clear any sentences that were already there 
		sentences.Clear();
		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
		/*

		*/
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		//Debug.Log(sentence)
		//dialogueText.text = sentence;
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}
	void EndDialogue()
	{
		Debug.Log("End of conversation.");
		//animator.SetBool("IsOpen", false);
		LotosPlayer player = FindObjectOfType<LotosPlayer>();
		player.dialogueOpen = false;
		player.DiaUI.SetActive(false);
	}
}