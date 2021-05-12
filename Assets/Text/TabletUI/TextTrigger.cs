using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public TextObject textInterface = new TextObject();
    public void TriggerText(){
        FindObjectOfType<TextManager>().StartText(textInterface);
    }
    
}
