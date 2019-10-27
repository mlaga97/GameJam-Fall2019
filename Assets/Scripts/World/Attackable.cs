using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : Taggable
{
  // TODO: Many other parameters
  public string itemID;
  public int health;

  // TODO: Take Weapon parameter
  public Item Attack() {
    health--;

    // TODO: Make destruction actually permanent
    if (health < 1) {
      Destroy(gameObject);
      return new Item(itemID);
    }

    return null;
  }
}
