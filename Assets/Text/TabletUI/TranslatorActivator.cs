using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslatorActivator : Translator
{
    public GameObject translateActivator;    
    private TextTrigger textTrigger;
    public void Activate() {
        FindObjectOfType<CameraScript>().translateButton.SetActive(true);
        textTrigger = GameObject.FindObjectOfType<TextTrigger>();
        textTrigger.TriggerText();
        translateActivator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
