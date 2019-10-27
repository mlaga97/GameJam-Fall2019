using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoboRoboHandler : NPC
{
  int currentQuest = 0;

  public Dialogue[] quest1_start;
  public Dialogue[] quest1_healing;
  public Dialogue[] quest1_complete;
  public Dialogue[] quest1_incomplete;

  public Dialogue[] quest2_start;
  public Dialogue[] quest2_healing;
  public Dialogue[] quest2_complete;
  public Dialogue[] quest2_incomplete;

  public override bool Interact() {
    switch(currentQuest) {
      case 0:
        quest0();
        return true;
      case 1:
        quest1();
        return true;
      default:
        return false;
    }
  }

  void quest0() {
    QueueDialogue(quest1_start);
    currentQuest++;
  }

  void quest1() {
    QueueDialogue(quest2_start);
    currentQuest++;
  }

  public void QueueDialogue(Dialogue[] dialogue) {
    Queue<Dialogue> dialogueQueue = new Queue<Dialogue>();

    foreach (Dialogue entry in dialogue) {
      dialogueQueue.Enqueue(entry);
    }

    FindObjectOfType<DialogueManager>().StartDialogue(dialogueQueue);
  }
}
