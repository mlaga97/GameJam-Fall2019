using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taggable : MonoBehaviour {
  public enum TagType {
    Controllable,
    Attackable,
    Walkable,
    Unwalkable,
    Mineable,
    Cutable,
    Collectable,
    Talkable,
    Questable,
    Tradeable,
    Interactable,
    Traversable,
    Repairable
  }

  public TagType[] tags;

  bool hasTag(TagType tagToCheck) {
    foreach (TagType tag in tags)
      if (tag == tagToCheck)
        return true;

    return false;
  }
}
