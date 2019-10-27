using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : Taggable {
  public virtual bool Interact() {
    return false;
  }
}
