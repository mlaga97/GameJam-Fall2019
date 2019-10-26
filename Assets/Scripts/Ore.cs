using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour {
  public string itemID;
  public int quantity;

  public Sprite sprite1;
  public Sprite sprite2;

  public SpriteRenderer spriteRenderer;

  void Start() {
    spriteRenderer = GetComponent<SpriteRenderer>();
    spriteRenderer.sprite = sprite1;

    StartCoroutine(Replenish());
  }

  IEnumerator Replenish() {
    while (true) {
      yield return new WaitForSeconds(1);
      if (quantity <= 10)
        quantity++;
    }
  }

  void Update() {
    if (quantity <= 0)
      spriteRenderer.sprite = sprite2;
    else
      spriteRenderer.sprite = sprite1;
  }

  // TODO: Check tool (by reference)
  public Item mine() {
    if (quantity-- > 0)
      return new Item(itemID);

    return null;
  }
}
