using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
  public Sprite playerFront;
  public Sprite playerRear;

  // Configurables
  static int waitTime = 5;

  // State variables
  string currentKey;
  int currentKeyDuration;
  int xDir = 1;
  int yDir = -1;

  private SpriteRenderer spriteRenderer;

  void Start() {
    spriteRenderer = GetComponent<SpriteRenderer>();
    spriteRenderer.sprite = playerFront;
  }

  // Handle movement
  // TODO: Add intialWaitTime
  void Update() {
    if (FindObjectOfType<PlayerHandler>().IsBusy()) return; // Skip the rest if we are "busy"

    string lastKey = currentKey;
    currentKey = "";

    // Check if we've been holding the key long enough to move again
    bool moveThisTick = false || (currentKeyDuration > waitTime);

    // Determine what key (if any) is being pressed
    if (Input.GetKey("w"))
      currentKey = "w";
    else if (Input.GetKey("a"))
      currentKey = "a";
    else if (Input.GetKey("s"))
      currentKey = "s";
    else if (Input.GetKey("d"))
      currentKey = "d";

    if (currentKey != lastKey) {
      // Reset if currentKey has changed
      moveThisTick = true;
      currentKeyDuration = 0;
    } else if (currentKey != "") {
      // Increment counter if still holding
      currentKeyDuration++;
    } else {
      // Halt movement otherwise
      moveThisTick = false;
    }

    if (moveThisTick) {
      currentKeyDuration = 0; // Reset counter

      // Handle Movement
      switch (currentKey) {
        case "w":
          yDir = 1;
          transform.Translate(0, 1, 0);
          break;
        case "a":
          xDir = -1;
          transform.Translate(-1, 0, 0);
          break;
        case "s":
          yDir = -1;
          transform.Translate(0, -1, 0);
          break;
        case "d":
          xDir = 1;
          transform.Translate(1, 0, 0);
          break;
      }

      // Handle Rendering
      if (yDir > 0) {
        spriteRenderer.sprite = playerRear;
        if (xDir < 0) {
          spriteRenderer.flipX = false;
        } else {
          spriteRenderer.flipX = true;
        }
      } else {
        spriteRenderer.sprite = playerFront;
        if (xDir > 0) {
          spriteRenderer.flipX = false;
        } else {
          spriteRenderer.flipX = true;
        }
      }
    }
  }
}
