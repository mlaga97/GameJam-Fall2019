using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HermitHandler : NPC
{
  public Dialogue[] goAwayText;

  public Dialogue[] quest1_start;
  public Dialogue[] quest1_complete;
  public Dialogue[] quest1_incomplete;
  private int slimesNeeded = 5;

  public override bool Interact() {
    QuestProgress questProgress = FindObjectOfType<DataManager>().questProgress;

    switch(questProgress.tutorial_questProgress) {
      case 1:
        quest1();
        return true;
      case 2:
        quest2();
        return true;
      case 3:
        quest3();
        return true;
      default:
        return false;
    }
  }

  void quest1() {
    QueueDialogue(goAwayText);
  }

  void quest2() {
    QueueDialogue(goAwayText);
  }

  void quest3() {
    QuestProgress questProgress = FindObjectOfType<DataManager>().questProgress;
    PlayerHandler playerHandler = FindObjectOfType<PlayerHandler>();
    Inventory inventory = playerHandler.GetInventory();

    if (questProgress.tutorial_subQuestProgress == 0) {
      QueueDialogue(quest1_start);
      questProgress.tutorial_subQuestProgress++;
      return;
    }

    if (questProgress.tutorial_subQuestProgress == 1) {
      if (slimesNeeded > inventory.CheckForItem(new Item("slime"))) {
        QueueDialogue(quest1_incomplete);
        return;
      }
    }

    QueueDialogue(quest1_complete);

    // Give power core
    inventory.addItem(new Item("spaceshipPowerCore"));

    questProgress.tutorial_questProgress++;
    questProgress.tutorial_subQuestProgress = 0;
    return;
  }
}
