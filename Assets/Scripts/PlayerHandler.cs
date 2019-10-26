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
}
