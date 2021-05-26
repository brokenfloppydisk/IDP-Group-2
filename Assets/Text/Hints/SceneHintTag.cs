using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHintTag : MonoBehaviour
{
    public bool hasHints;
    private void Awake() {
        Hints hints = FindObjectOfType<CameraScript>().hints;
        if (hints) {
            if (!hasHints) {
                hints.openButtons[0].gameObject.SetActive(false);
            } else {
                hints.openButtons[0].gameObject.SetActive(true);
            }
        }
    }
}
