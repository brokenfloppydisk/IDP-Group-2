using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public TextObject textInterface = new TextObject();
    [SerializeField]
    public TextManager textManager;
    private void Start() {
        if (textManager == null) {
            textManager = TextManager.Instance;
        }
    }
    public void TriggerText(){
        textManager.StartText(textInterface);
    }
    public void TriggerText(TextObject textObject) {
        textManager.StartText(textObject);
    }
}
