using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {
  private Queue<Dialogue> dialogue;

  void Setup() {
    // TODO: This won't work unless parent object known...
    //FindObjectOfType<DialogueText>().SetActive(false);
  }

  void Update() {
    if(Input.GetKeyDown("space")) {
      DisplayNextSentence();
    }
  }

  public void StartDialogue(Queue<Dialogue> dialogue) {
    this.dialogue = dialogue;

    // TODO: This won't work unless parent object known...
    //FindObjectOfType<DialogueText>().SetActive(true);

    // Block player control input
    FindObjectOfType<PlayerHandler>().StartBusy();

    DisplayNextSentence();
  }

  public void DisplayNextSentence() {
    if (dialogue.Count == 0) {
      EndDialogue();
      return;
    }

    Dialogue entry = dialogue.Dequeue();

    string text = entry.name + ": " + entry.sentence;

    FindObjectOfType<DialogueText>().SetDialogueText(text);
  }

  public void EndDialogue() {
    // Un-block player control input
    FindObjectOfType<PlayerHandler>().StopBusy();

    // TODO: This won't work unless parent object known...
    //FindObjectOfType<DialogueText>().SetActive(false);
    FindObjectOfType<DialogueText>().SetDialogueText("");
  }
}
