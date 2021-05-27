using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeypadPuzzleDoor : MonoBehaviour
{
    void Awake() {
        if (!CameraScript.Instance.bayDoorOpen) {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
