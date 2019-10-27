using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

  public Dialogue[] quest3_healing;
  public Dialogue[] quest3_incomplete;
  public Dialogue[] quest3_complete;

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
      case 4:
        quest4();
        return true;
      case 5:
        quest5();
        return true;
      default:
        return false;
    }
  }

  void quest1() {
    QuestProgress questProgress = FindObjectOfType<DataManager>().questProgress;
    PlayerHandler playerHandler = FindObjectOfType<PlayerHandler>();
    Inventory inventory = playerHandler.GetInventory();

    if (questProgress.tutorial_subQuestProgress == 0) {
      QueueDialogue(quest1_start);
      questProgress.tutorial_subQuestProgress++;
      return;
    }

    if (questProgress.tutorial_subQuestProgress == 1) {
      if (ironNeeded > inventory.CheckForItem(new Item("ore.iron"))) {
        QueueDialogue(quest1_incomplete);
        return;
      }
    }

    QueueDialogue(quest1_complete);
    questProgress.tutorial_questProgress++;
    questProgress.tutorial_subQuestProgress = 0;
    return;
  }

  void quest2() {
    QuestProgress questProgress = FindObjectOfType<DataManager>().questProgress;
    PlayerHandler playerHandler = FindObjectOfType<PlayerHandler>();
    Inventory inventory = playerHandler.GetInventory();

    if (questProgress.tutorial_subQuestProgress == 0) {
      QueueDialogue(quest2_start);
      questProgress.tutorial_subQuestProgress++;
      return;
    }

    if (questProgress.tutorial_subQuestProgress == 1) {
      if (armsNeeded > inventory.CheckForItem(new Item("hoboRoboArm"))) {
        QueueDialogue(quest2_incomplete);
        return;
      }
    }

    QueueDialogue(quest2_complete);

    // Give panel
    inventory.addItem(new Item("spaceshipControlPanel"));

    questProgress.tutorial_questProgress++;
    questProgress.tutorial_subQuestProgress = 0;
    return;
  }

  void quest3() {
    QuestProgress questProgress = FindObjectOfType<DataManager>().questProgress;
    QueueDialogue(quest3_incomplete);
  }

  void quest4() {
    QuestProgress questProgress = FindObjectOfType<DataManager>().questProgress;
    QueueDialogue(quest3_complete);
    questProgress.tutorial_questProgress++;
  }

  // TODO: Add scenechange to DialogueManager or PlayerManager
  void quest5() {
    SceneManager.LoadScene("ToTheForest");
  }
}
