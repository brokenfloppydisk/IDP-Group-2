using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField]
    private int index;
    [SerializeField]
    private bool usingText;
    [SerializeField]
    private bool arrow;
    public void Activate() {
        FindObjectOfType<CameraScript>().hiddenButtons[index].SetActive(true);
        if (usingText) {
            FindObjectOfType<TextTrigger>().TriggerText();
        }
        if (arrow) {
            FindObjectOfType<CameraScript>().hiddenButtons[2].GetComponent<Arrow>().Flash();
        }
        gameObject.SetActive(false);
    }
}
