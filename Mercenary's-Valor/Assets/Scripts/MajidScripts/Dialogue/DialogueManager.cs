using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public Image charBox;
    public Text dialogueText;
    public Queue<string> sentences;

    public Animator charAnimator;
    public Animator dialogueAnimator;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        charAnimator.SetBool("IsOpen", true);
        dialogueAnimator.SetBool("IsOpen", true);
        charBox = dialogue.charImage;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
           DisplayNextScentence();
    }
        public void DisplayNextScentence()
        {
            if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
            string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeScentence(sentence));
            }

    IEnumerator TypeScentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        charAnimator.SetBool("IsOpen", true);
        dialogueAnimator.SetBool("IsOpen", true);
    }
}
