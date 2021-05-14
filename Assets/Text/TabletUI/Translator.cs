using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Translator : MonoBehaviour
{  
    public List<Text> text = new List<Text>();
    private List<int> fontSizes = new List<int>();
    public Font font;

    public void Awake() {
        for (int i = 0; i < text.Count; i++) {
            fontSizes.Add(50);
        }
    }
    public void UpdateFontSize() {
        for (int i = 0; i < text.Count; i++) {
            fontSizes[i] = text[i].fontSize*8/10;
        }
    }
    public void Translate() {
        for (int i = 0; i < text.Count; i++) {
            text[i].font = font;
            text[i].fontSize = fontSizes[i];
            text[i].lineSpacing = 1.1f;
        }
    }

}