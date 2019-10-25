using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
  // Configurables
  static int waitTime = 5;

  // State variables
  string currentKey;
  int currentKeyDuration;

  // Start is called before the first frame update
  void Start() {
  }

  // Update is called once per frame
  void Update() {
    HandleMovement();
  }

  // TODO: Add intialWaitTime
  void HandleMovement() {
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

    // Handle Movement
    if (moveThisTick) {
      currentKeyDuration = 0; // Reset counter

      switch (currentKey) {
        case "w":
          transform.Translate(0, 1, Time.deltaTime);
          break;
        case "a":
          transform.Translate(-1, 0, Time.deltaTime);
          break;
        case "s":
          transform.Translate(0, -1, Time.deltaTime);
          break;
        case "d":
          transform.Translate(1, 0, Time.deltaTime);
          break;
      }
    }
  }
}
