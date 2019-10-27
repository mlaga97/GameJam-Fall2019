using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueText : MonoBehaviour
{
  public void SetDialogueText(string dialogText) {
    gameObject.GetComponent<UnityEngine.UI.Text>().text = dialogText;
  }

  public void SetActive(bool active) {
    gameObject.SetActive(active);
  }
}
