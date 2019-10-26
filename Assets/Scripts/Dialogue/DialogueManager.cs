using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {
  public GameObject dialogueTextBox;

  private Queue<Dialogue> dialogue;

  void Setup() {
    dialogueTextBox.SetActive(false);
  }

  void Update() {
    if(Input.GetKeyDown("space")) {
      DisplayNextSentence();
    }
  }

  public void StartDialogue(Queue<Dialogue> dialogue) {
    this.dialogue = dialogue;
    dialogueTextBox.SetActive(true);

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

    dialogueTextBox.GetComponent<UnityEngine.UI.Text>().text = entry.name + ": " + entry.sentence;
  }

  public void EndDialogue() {
    // Un-block player control input
    FindObjectOfType<PlayerHandler>().StopBusy();

    dialogueTextBox.SetActive(false);
  }
}
