using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenHandler : MonoBehaviour
{
  public string sceneName;

  void Update() {
    if (Input.anyKeyDown) {
      SceneManager.LoadScene(sceneName);
    }
  }
}
