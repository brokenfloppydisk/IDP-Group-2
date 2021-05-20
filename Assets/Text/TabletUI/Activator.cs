using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : Translator
{
    public GameObject activator;    
    private TextTrigger textTrigger;
    public bool usingTranslator;
    public void Activate() {
        if (usingTranslator) {
            FindObjectOfType<CameraScript>().translateButton.SetActive(true);
        }
        else {
            FindObjectOfType<CameraScript>().ciphersButton.SetActive(true);
        }
        textTrigger = GameObject.FindObjectOfType<TextTrigger>();
        textTrigger.TriggerText();
        activator.SetActive(false);
    }
}
