using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
  string itemID;

  public void log() {
    Debug.Log("ItemID: " + itemID);
  }

  public Item(string itemID) {
    this.itemID = itemID;
  }
}
