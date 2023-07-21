using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("System Dialogue")]

    [SerializeField]
    public TextMeshProUGUI titleText;

    [SerializeField]
    public TextMeshProUGUI dialogueText;

    [Header("Animation")]
    [SerializeField]
    public Animator dialogueAnimation;

    [Header("Audio Source")]
    [SerializeField]
    public AudioSource typeSentenceAudio;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        titleText.text = string.Empty;
        dialogueText.text = string.Empty;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //start animation of the dialogue box
        dialogueAnimation.SetBool("IsOpen", true);

        titleText.text = dialogue.title;

        //clear the queue
        sentences.Clear();

        //put sentenes in the queue
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            //typeSentenceAudio.Play();
            dialogueText.text += letter;
            
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void EndDialogue()
    {
        dialogueAnimation.SetBool("IsOpen", false);

        FindObjectOfType<LevelLoader>().LoadScene();
    }
}
