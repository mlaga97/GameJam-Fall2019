using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
  private GameObject currentTile; // TODO: Find a better way

  // State variables
  Inventory inventory;
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

  // TODO: Probably don't?
  public GameObject GetCurrentTile() {
    return currentTile;
  }

  // TODO: Probably don't?
  public Inventory GetInventory() {
    return inventory;
  }

  // Start is called before the first frame update
  void Start() {
    inventory = FindObjectOfType<DataManager>().inventory;
  }

  // Update is called once per frame
  void Update() {
    if (busy) return; // Skip the rest if we are "busy"

    HandleInventory();
  }

  void OnTriggerStay2D(Collider2D collider) {
    currentTile = collider.gameObject;
  }

  void OnTriggerExit2D(Collider2D collider) {
    currentTile = null;
  }

  void HandleInventory() {
    // Dump inventory if 
    if (Input.GetKeyDown("e")) {
      Debug.Log(JsonUtility.ToJson(inventory));
      inventory.logItems();
    }
  }
}
