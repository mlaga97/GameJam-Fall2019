using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Item;
using static Inventory;

public class PlayerHandler : MonoBehaviour
{
  public GameObject statusTextBox;

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
    HandleInventory();

    string statusText = "Overworld";

    // Handle mining
    if (currentTile && currentTile.tag == "Mineable") {
      statusText = "Press f to mine!";

      if (Input.GetKey("f")) {
        statusText = "Mining!";
       
        Ore ore = currentTile.GetComponent<Ore>();
        Item drop = ore.mine();

        if (drop != null) {
          statusText = "Mining succeeded!";
          inventory.addItem(drop);
        } else {
          statusText = "Mining failed!";
        }
      }
    }

    // Handle interacting
    if (currentTile && currentTile.tag == "Interactable") {
      statusText = "Press f to talk!";

      if (Input.GetKey("f")) {
        NPC npc = currentTile.GetComponent<NPC>();
        statusText = npc.interact();
      }
    }

    // Update statusTextBox
    statusTextBox.GetComponent<UnityEngine.UI.Text>().text = statusText;
  }

  void OnTriggerStay2D(Collider2D collider) {
    currentTile = collider.gameObject;
  }

  void OnTriggerExit2D(Collider2D collider) {
    currentTile = null;
  }

  void HandleInventory() {
    // Dump inventory if 
    if (Input.GetKeyDown("e"))
      inventory.logItems();
  }
}
