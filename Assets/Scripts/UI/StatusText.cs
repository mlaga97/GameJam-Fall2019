using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusText : MonoBehaviour
{
  public void SetStatusText(string statusText) {
    gameObject.GetComponent<UnityEngine.UI.Text>().text = statusText;
  }
}
