using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
  public static DataManager instance;

  public Inventory inventory = new Inventory();

  public QuestProgress questProgress = new QuestProgress();

  void Awake() {
    if (instance == null)
      instance = this;

    else if (instance != this)
      Destroy(gameObject);

    DontDestroyOnLoad(gameObject);
  }
}
