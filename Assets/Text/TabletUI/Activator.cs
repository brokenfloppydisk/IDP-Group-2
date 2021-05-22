using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public int index;
    public void Activate() {
        FindObjectOfType<CameraScript>().hiddenButtons[index].SetActive(true);
        GameObject.FindObjectOfType<TextTrigger>().TriggerText();
        gameObject.SetActive(false);
    }
}
