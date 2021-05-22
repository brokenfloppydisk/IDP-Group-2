using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public TextObject textInterface = new TextObject();
    [SerializeField]
    private TextManager textManager;
    private void Awake() {
        if (textManager == null) {
            textManager = FindObjectOfType<TextManager>();
        }
    }
    public void TriggerText(){
        textManager.StartText(textInterface);
    }
    public void TriggerText(TextObject textObject) {
        textManager.StartText(textObject);
    }
}
