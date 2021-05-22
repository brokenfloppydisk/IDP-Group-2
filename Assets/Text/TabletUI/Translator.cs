using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Translator : MonoBehaviour
{  
    public List<Text> text = new List<Text>();
    public Font font;
    private TextManager textManager;
    public void Start() {
        textManager = FindObjectOfType<TextManager>();
    }
    public void Translate() {
        for (int i = 0; i < text.Count; i++) {
            text[i].font = font;
            text[i].lineSpacing = 1.0f;
        }  
    }
}