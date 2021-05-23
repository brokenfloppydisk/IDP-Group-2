using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public int index;
    public bool usingText;
    public void Activate() {
        FindObjectOfType<CameraScript>().hiddenButtons[index].SetActive(true);
        if (usingText) {
            GameObject.FindObjectOfType<TextTrigger>().TriggerText();
        }
        gameObject.SetActive(false);
    }
}
