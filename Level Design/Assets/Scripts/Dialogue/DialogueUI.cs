using System.Collections; //for queue
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for updating UI 

public class DialogueUI : MonoBehaviour
{

	public GameObject NameText;
	public Text dialogueText;
	private bool hasQuest;
	private Quest quest;

	//public Animator animator;


	private Queue<string> sentences;
	void Start()
	{
		sentences = new Queue<string>();
	}	

	public void StartDialogue(NPC npc)
     {
		hasQuest = npc.hasQuest;
		npc.hasQuest = false;
		quest = npc.quest;
		Debug.Log("Starting convo with " + npc.name); //testing
		NameText.GetComponent<Text>().text = npc.name + "";

		Dialogue d;
		if (!npc.hasMet)
		{
			d = new Dialogue(npc.name, npc.firstDialogue);
			npc.hasMet = true;
		}
		else
			d = new Dialogue(npc.name, npc.defaultDialogue);

		sentences.Clear();
		foreach (string sentence in d.sentences)
		{
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();

	}		

	/*
	public void StartDialogue(Dialogue dialogue, bool q)
	{
		hasQuest = q;

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
	}
	*/

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
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
		LotosPlayer player = FindObjectOfType<LotosPlayer>();
		player.dialogueOpen = false;
		player.DiaUI.SetActive(false);

		if (hasQuest)
          {
			//open quest from Quest UI
			FindObjectOfType<QuestUI>().OpenQuest(quest);
			hasQuest = false;
          }			
		//animator.SetBool("IsOpen", false);

		
	}
}