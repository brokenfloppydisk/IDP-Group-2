using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public TextObject textInterface = new TextObject();
    private TextManager textManager;
    private void Awake() {
        textManager = FindObjectOfType<TextManager>();
    }
    public void TriggerText(){
        textManager.StartText(textInterface);
        textManager.translated = false;
    }
    
}
