using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : DialogueTrigger {
  public bool interact() {
    TriggerDialogue();
    return true;
  }
}
