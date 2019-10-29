using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
  public bool reset = false;

  public Inventory inventory = new Inventory();

  public QuestProgress questProgress = new QuestProgress();

  // Singleton stuff
  public static DataManager instance;
  void Awake() {
    if (instance == null) {
      Debug.Log("Initializing game state!");
      instance = this;
    } else if (instance != this) {
      Debug.Log("Resetting game state!");

      // TODO: Reset better
      instance.inventory = new Inventory();
      instance.questProgress = new QuestProgress();

      Destroy(gameObject);
    }

    DontDestroyOnLoad(gameObject);
  }
}
