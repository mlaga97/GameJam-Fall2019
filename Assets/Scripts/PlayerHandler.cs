using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Item;
using static Inventory;

public class PlayerHandler : MonoBehaviour
{
  // Configurables
  static int waitTime = 5;

  // State variables
  string currentKey;
  int currentKeyDuration;
  Inventory inventory = new Inventory();

  // TODO: Find a better way
  GameObject currentTile;

  // Start is called before the first frame update
  void Start() {
    inventory.addItem(new Item("test"));
  }

  // Update is called once per frame
  void Update() {
    HandleMovement();
    HandleInventory();

    if (currentTile && currentTile.tag == "Mineable" && Input.GetKey("f")) {
        Debug.Log("Mining!");
       
        Ore ore = currentTile.GetComponent<Ore>();
        Item drop = ore.mine();

        if (drop != null) {
          Debug.Log("Mining succeeded!");
          inventory.addItem(drop);
        } else {
          Debug.Log("Mining failed!");
        }
      }
  }

  void OnTriggerStay2D(Collider2D collider) {
    currentTile = collider.gameObject;
  }

  void HandleInventory() {
    // Dump inventory if 
    if (Input.GetKeyDown("e"))
      inventory.logItems();
  }

  // TODO: Add intialWaitTime
  void HandleMovement() {
    string lastKey = currentKey;
    currentKey = "";

    // Check if we've been holding the key long enough to move again
    bool moveThisTick = false || (currentKeyDuration > waitTime);

    // Determine what key (if any) is being pressed
    if (Input.GetKey("w"))
      currentKey = "w";
    else if (Input.GetKey("a"))
      currentKey = "a";
    else if (Input.GetKey("s"))
      currentKey = "s";
    else if (Input.GetKey("d"))
      currentKey = "d";

    if (currentKey != lastKey) {
      // Reset if currentKey has changed
      moveThisTick = true;
      currentKeyDuration = 0;
    } else if (currentKey != "") {
      // Increment counter if still holding
      currentKeyDuration++;
    } else {
      // Halt movement otherwise
      moveThisTick = false;
    }

    // Handle Movement
    if (moveThisTick) {
      currentKeyDuration = 0; // Reset counter

      switch (currentKey) {
        case "w":
          transform.Translate(0, 1, 0);
          break;
        case "a":
          transform.Translate(-1, 0, 0);
          break;
        case "s":
          transform.Translate(0, -1, 0);
          break;
        case "d":
          transform.Translate(1, 0, 0);
          break;
      }
    }
  }
}
