using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    private Queue<string> sentences;

    private EndOfDialogue EndDialogue;

    private bool conversationStarted = false;

    public Text nameText;
    public Text dialogueText;

    public static DialogueManager Instance { get { return instance; } }

    private void Awake() {
        instance = this;
        sentences = new Queue<string>();
    }

    private void Update() {
        
        if (conversationStarted) {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) {
                DisplayNextSentence();
            }
        }

    }

    public void StartDialogue(Dialogue dialogue, EndOfDialogue endAction) {

        nameText.transform.parent.parent.gameObject.SetActive(true);

        EndDialogue = endAction;

        sentences.Clear();

        nameText.text = dialogue.name;

        foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        conversationStarted = true;
    }

    private void DisplayNextSentence() {

        if (sentences.Count == 0) {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();

        dialogueText.text = sentence;

    }

    private void EndDialog() {
        conversationStarted = false;
        nameText.transform.parent.parent.gameObject.SetActive(false);
        EndDialogue();
    }
}
