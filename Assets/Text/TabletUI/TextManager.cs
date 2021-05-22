using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<Font> fontsQueue;
    public Text titleText;
    public Text bodyText;
    public Image tabletBackground;
    public List<Animator> animators;
    private TextObject textObject;
    [System.NonSerialized]
    public bool translated;

    // Start is called before the first frame update
    void Start() {
        sentences = new Queue<string>();
        fontsQueue = new Queue<Font>();
    }
    public void StartText(TextObject textObj) {
        for (int i = 0; i < animators.Count; i++) {
            animators[i].SetBool("TabletOpen", true);
        }
        textObject = textObj;
        titleText.fontSize = textObj.titleFontSize;
        titleText.color = textObj.textColor;
        titleText.font = textObj.fonts[0];
        tabletBackground.color = textObj.bgColor;
        bodyText.color = textObj.textColor;
        bodyText.fontSize = textObj.fontSize;
        bodyText.font = textObj.fonts[0];
        titleText.text = textObj.title;
        sentences.Clear();
        for (int i = 0; i < textObj.sentences.Length; i++) {
            string sentence_ = textObj.sentences[i];
            sentences.Enqueue(sentence_);
            if (textObj.multipleFonts) {
                Font font_ = textObj.fonts[i];
                fontsQueue.Enqueue(font_);
            }
        }
        next();
    }

    public void next() {
        if (sentences.Count == 0) {
            EndText();
            return;
        }
        string sentence = sentences.Dequeue();
        if (textObject.multipleFonts) {
            Font font = fontsQueue.Dequeue();
            bodyText.font = font;
        }
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence) {
        bodyText.text = "";
        char[] sentence_array = sentence.ToCharArray();
        for (int i = 0; i < sentence_array.Length; i++) {
            char letter = sentence_array[i];
            bodyText.text += letter;
            if (i%2 == 1) {
                yield return null;
            }
        }
    }

    public void EndText() {
        for (int i = 0; i < animators.Count; i++) {
            animators[i].SetBool("TabletOpen", false);
        }
    }
}
