using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoboRoboHandler : NPC
{
  public Dialogue[] quest1_start;
  public Dialogue[] quest1_healing;
  public Dialogue[] quest1_complete;
  public Dialogue[] quest1_incomplete;
  private int ironNeeded = 10;

  public Dialogue[] quest2_start;
  public Dialogue[] quest2_healing;
  public Dialogue[] quest2_complete;
  public Dialogue[] quest2_incomplete;
  private int armsNeeded = 1;

  public override bool Interact() {
    QuestProgress questProgress = FindObjectOfType<DataManager>().questProgress;

    switch(questProgress.tutorial_hoboRobo_questProgress) {
      case 1:
        quest1();
        return true;
      case 2:
        quest2();
        return true;
      default:
        return false;
    }
  }

  void quest1() {
    QuestProgress questProgress = FindObjectOfType<DataManager>().questProgress;
    PlayerHandler playerHandler = FindObjectOfType<PlayerHandler>();
    Inventory inventory = playerHandler.GetInventory();

    if (questProgress.tutorial_hoboRobo_subQuestProgress == 0) {
      QueueDialogue(quest1_start);
      questProgress.tutorial_hoboRobo_subQuestProgress++;
      return;
    }

    if (questProgress.tutorial_hoboRobo_subQuestProgress == 1) {
      // TODO: Check health

      if (ironNeeded > inventory.CheckForItem(new Item("ore.iron"))) {
        QueueDialogue(quest1_incomplete);
        return;
      }
    }

    QueueDialogue(quest1_complete);
    questProgress.tutorial_hoboRobo_questProgress++;
    questProgress.tutorial_hoboRobo_subQuestProgress = 0;
    return;
  }

  void quest2() {
    QuestProgress questProgress = FindObjectOfType<DataManager>().questProgress;
    PlayerHandler playerHandler = FindObjectOfType<PlayerHandler>();
    Inventory inventory = playerHandler.GetInventory();

    if (questProgress.tutorial_hoboRobo_subQuestProgress == 0) {
      QueueDialogue(quest2_start);
      questProgress.tutorial_hoboRobo_subQuestProgress++;
      return;
    }

    if (questProgress.tutorial_hoboRobo_subQuestProgress == 1) {
      if (armsNeeded > inventory.CheckForItem(new Item("hoboRoboArm"))) {
        QueueDialogue(quest2_incomplete);
        return;
      }
    }

    QueueDialogue(quest2_complete);

    // Give panel
    inventory.addItem(new Item("spaceshipControlPanel"));

    questProgress.tutorial_hoboRobo_questProgress++;
    questProgress.tutorial_hoboRobo_subQuestProgress = 0;
    return;
  }

  public void QueueDialogue(Dialogue[] dialogue) {
    Queue<Dialogue> dialogueQueue = new Queue<Dialogue>();

    foreach (Dialogue entry in dialogue) {
      dialogueQueue.Enqueue(entry);
    }

    FindObjectOfType<DialogueManager>().StartDialogue(dialogueQueue);
  }
}
