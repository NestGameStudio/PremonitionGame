using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    private Queue<string> sentences;
    private Queue<string> speakerName;

    private EndOfDialogue EndDialogue;

    private int maxDialogueOptions = 1;

    private DialoguePrompt[] dialoguePrompts;
    [HideInInspector]
    public bool DialogueSelection = false;
    private int currentSelectedPrompt;


    [HideInInspector]
    public bool ConversationStarted = false;

    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueOptions;

    public static DialogueManager Instance { get { return instance; } }

    private void Awake() {
        instance = this;
        sentences = new Queue<string>();
        speakerName = new Queue<string>();
    }

    private void Update() {
        
        if (ConversationStarted) {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) {
                DisplayNextSentence();
            }
        } 

        if (DialogueSelection) {

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("Mouse ScrollWheel") > 0f) {

                if (currentSelectedPrompt > 0) {
                    currentSelectedPrompt--;

                    dialogueOptions.transform.GetChild(currentSelectedPrompt + 1).GetComponent<Text>().fontStyle = FontStyle.Normal;
                }

                dialogueOptions.transform.GetChild(currentSelectedPrompt).GetComponent<Text>().fontStyle = FontStyle.Bold;


            } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxis("Mouse ScrollWheel") < 0f) {

                if (currentSelectedPrompt < maxDialogueOptions) {
                    currentSelectedPrompt++;

                    dialogueOptions.transform.GetChild(currentSelectedPrompt - 1).GetComponent<Text>().fontStyle = FontStyle.Normal;
                }

                dialogueOptions.transform.GetChild(currentSelectedPrompt).GetComponent<Text>().fontStyle = FontStyle.Bold;

            } else if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) {

                StartDialogue(dialoguePrompts[currentSelectedPrompt].dialogue);
                dialogueOptions.transform.GetChild(currentSelectedPrompt).GetComponent<Text>().fontStyle = FontStyle.Normal;
                DialogueSelection = false;
                dialogueOptions.SetActiveRecursively(false);
            }
        }

    }

    public void SelectPrompt(DialoguePrompt[] _dialoguePrompts, EndOfDialogue endAction) {

        nameText.transform.parent.gameObject.SetActive(false);

        dialogueOptions.transform.parent.gameObject.SetActive(true);
        dialogueOptions.SetActive(true);

        dialoguePrompts = _dialoguePrompts;
        EndDialogue = endAction;

        maxDialogueOptions = dialoguePrompts.Length - 1;
        int index = 0;

        foreach (Transform dialogueChild in dialogueOptions.GetComponentInChildren<Transform>(true)) {

            if (index <= maxDialogueOptions) {

                dialogueChild.GetComponent<Text>().text = dialoguePrompts[index].DialogPrompt;
                dialogueChild.gameObject.SetActive(true);

                index++;
            }
        }

        dialogueOptions.transform.GetChild(0).GetComponent<Text>().fontStyle = FontStyle.Bold;
        currentSelectedPrompt = 0;

        dialogueOptions.transform.parent.parent.gameObject.SetActive(true);
        dialogueOptions.SetActive(true);

        DialogueSelection = true;

    }

    public void StartDialogue(Dialogue[] dialogue) {

        nameText.transform.parent.gameObject.SetActive(true);

        sentences.Clear();

        foreach(Dialogue dialogueSentence in dialogue) {
            sentences.Enqueue(dialogueSentence.Sentence);
            speakerName.Enqueue(dialogueSentence.SpeakerName);
        }

        DisplayNextSentence();
        ConversationStarted = true;
    }

    private void DisplayNextSentence() {

        if (sentences.Count == 0) {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = speakerName.Dequeue();

        nameText.text = name;
        nameText.fontStyle = FontStyle.Bold;
        dialogueText.text = sentence;

    }

    private void EndDialog() {
        nameText.transform.parent.parent.gameObject.SetActive(false);
        ConversationStarted = false;
        EndDialogue();
    }
}
