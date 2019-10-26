using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
  public GameObject statusTextBox;

  // State variables
  string currentKey;
  bool interactionCooldown = false;
  string statusText = "";
  Inventory inventory = new Inventory();
  bool busy = false;

  public void StartBusy() {
    busy = true;
  }

  public void StopBusy() {
    busy = false;
  }

  public bool IsBusy() {
    return busy;
  }

  // TODO: Find a better way
  GameObject currentTile;

  // Start is called before the first frame update
  void Start() {
    inventory.addItem(new Item("test"));
  }

  IEnumerator InteractCooldown() {
    yield return new WaitForSeconds(1);
    interactionCooldown = false;
  }

  // Update is called once per frame
  void Update() {
    if (busy) return; // Skip the rest if we are "busy"

    HandleInventory();

    if (!interactionCooldown)
      statusText = "Overworld";

    // Handle mining
    if (currentTile && !interactionCooldown && currentTile.tag == "Mineable") {
      statusText = "Press f to mine!";

      if (Input.GetKey("f")) {
        // Start cooldown timer
        StartCoroutine(InteractCooldown());
        interactionCooldown = true;

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
    if (currentTile && !interactionCooldown && currentTile.tag == "Interactable") {
      statusText = "Press f to talk!";

      if (Input.GetKey("f")) {
        // Start cooldown timer
        StartCoroutine(InteractCooldown());
        interactionCooldown = true;

        Interactable interactable = currentTile.GetComponent<Interactable>();

        if (interactable.interact())
          statusText = "Talking... (Press Space to Continue)";
        else
          statusText = "They don't seem to have much to say...";
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
