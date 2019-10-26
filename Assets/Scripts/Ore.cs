using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour {
  public string itemID;
  public int quantity;

  void Start() {
  }

  void Update() {
  }

  // TODO: Check tool (by reference)
  public Item mine() {
    if (quantity-- > 0)
      return new Item(itemID);

    return null;
  }
}
