using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineable : Taggable
{
  public Sprite fullSprite;
  public Sprite emptySprite;

  public string itemID;
  public float regenTime;
  public int initialQuantity;

  private int quantity;
  private SpriteRenderer spriteRenderer;

  // TODO: ???
  //new public TagType[] tags = new TagType[2] {TagType.Walkable, TagType.Mineable};

  void Start() {
    Instantiate(gameObject);

    spriteRenderer = GetComponent<SpriteRenderer>();
    spriteRenderer.sprite = fullSprite;

    quantity = initialQuantity;

    StartCoroutine(Replenish());
  }

  IEnumerator Replenish() {
    while (true) {
      yield return new WaitForSeconds(regenTime);
      if (quantity < initialQuantity)
        quantity++;
    }
  }

  void Update() {
    if (quantity < 1)
      spriteRenderer.sprite = emptySprite;
    else
      spriteRenderer.sprite = fullSprite;
  }

  // TODO: Check tool (by reference)
  public Item mine() {
    if (quantity > 0) {
      quantity--;
      return new Item(itemID);
    }

    return null;
  }
}
