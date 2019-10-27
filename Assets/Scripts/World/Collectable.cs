using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Taggable
{
  // TODO: Many other parameters
  public string itemID;

  public Item Collect() {
    // TODO: Make destruction actually permanent
    Destroy(gameObject);

    return new Item(itemID);
  }
}
