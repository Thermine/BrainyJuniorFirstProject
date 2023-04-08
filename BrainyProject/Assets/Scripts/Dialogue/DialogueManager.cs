using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences;

    public Text dialogueText;

    public Animator animator;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialoguee dialoguee)
    {
        animator.SetBool("IsOpen", true);

        sentences.Clear();

        foreach (string sentence in dialoguee.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence; 
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    
}
