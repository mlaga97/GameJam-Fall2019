using System.Collections;
using System.Collections.Generic;

using static Item;

public class Inventory {
  // TODO: Actually decide how to store inventory
  List<Item> items = new List<Item>();

  public void logItems() {
    foreach (Item item in items) {
      item.log();
    }
  }

  public void addItem(Item item) {
    items.Add(item);
  }

  public void removeItem() {
  }
}
