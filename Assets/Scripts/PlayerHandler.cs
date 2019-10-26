using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Item;
using static Inventory;

public class PlayerHandler : MonoBehaviour
{
  public GameObject txt;

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

    txt.GetComponent<UnityEngine.UI.Text>().text = "Overworld";

    if (currentTile && currentTile.tag == "Mineable") {
      txt.GetComponent<UnityEngine.UI.Text>().text = "Press f to mine!";

      if (Input.GetKey("f")) {
        txt.GetComponent<UnityEngine.UI.Text>().text = "Mining!";
       
        Ore ore = currentTile.GetComponent<Ore>();
        Item drop = ore.mine();

        if (drop != null) {
          txt.GetComponent<UnityEngine.UI.Text>().text = "Mining succeeded!";
          inventory.addItem(drop);
        } else {
          txt.GetComponent<UnityEngine.UI.Text>().text = "Mining failed!";
        }
      }
    }
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
