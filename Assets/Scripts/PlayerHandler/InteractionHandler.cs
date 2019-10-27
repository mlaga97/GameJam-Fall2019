using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
  string status = "";
  bool interactionCooldown = false;

  IEnumerator InteractCooldown(float cooldownTime) {
    yield return new WaitForSeconds(cooldownTime);
    interactionCooldown = false;
  }

  void Update() {
    StatusText statusText = FindObjectOfType<StatusText>(); // TODO: UIHandler?
    PlayerHandler player = FindObjectOfType<PlayerHandler>();
    GameObject currentTile = player.GetCurrentTile();
    Inventory inventory = player.GetInventory();

    if (player.IsBusy()) return; // Skip the rest if we are "busy"

    if (!interactionCooldown)
      status = "Overworld";

    // Handle mining
    if (currentTile && !interactionCooldown && currentTile.tag == "Mineable") {
      status = "Press f to mine!";

      if (Input.GetKey("f")) {
        // Start cooldown timer
        StartCoroutine(InteractCooldown(0.2f));
        interactionCooldown = true;

        status = "Mining!";
       
        Ore ore = currentTile.GetComponent<Ore>();
        Item drop = ore.mine();

        if (drop != null) {
          status = "Mining succeeded!";
          inventory.addItem(drop);
        } else {
          status = "Mining failed!";
        }
      }
    }

    // Handle interacting
    if (currentTile && !interactionCooldown && currentTile.tag == "Interactable") {
      status = "Press f to talk!";

      if (Input.GetKey("f")) {
        // Start cooldown timer
        StartCoroutine(InteractCooldown(1.0f));
        interactionCooldown = true;

        Interactable interactable = currentTile.GetComponent<Interactable>();

        if (interactable.Interact())
          status = "Talking... (Press Space to Continue)";
        else
          status = "They don't seem to have much to say...";
      }
    }

    // Update status
    statusText.SetStatusText(status);
  }
}
