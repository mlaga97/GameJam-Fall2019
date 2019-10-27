using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {
  public void QueueDialogue(Dialogue[] dialogue) {
    Queue<Dialogue> dialogueQueue = new Queue<Dialogue>();

    foreach (Dialogue entry in dialogue) {
      dialogueQueue.Enqueue(entry);
    }

    FindObjectOfType<DialogueManager>().StartDialogue(dialogueQueue);
  }
}
