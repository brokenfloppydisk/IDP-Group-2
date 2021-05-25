using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeypadPuzzleDoor : MonoBehaviour
{
    void Awake() {
        if (!FindObjectOfType<CameraScript>().bayDoorOpen) {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
