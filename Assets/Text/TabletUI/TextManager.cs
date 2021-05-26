using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 0649
public class TextManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<string> titlesQueue;
    private Queue<Font> fontsQueue;
    public Text titleText;
    public Text bodyText;
    public Image tabletBackground;
    public List<Animator> animators;
    private TextObject textObject;
    private CameraScript cameraScript;
    [SerializeField]
    private string animatorBoolName;
    [SerializeField]
    private bool usingAnimators;
    // Start is called before the first frame update
    void Start() {
        cameraScript = FindObjectOfType<CameraScript>();
        sentences = new Queue<string>();
        titlesQueue = new Queue<string>();
        fontsQueue = new Queue<Font>();
    }
    public void StartText(TextObject textObject) {
        sentences = new Queue<string>();
        titlesQueue = new Queue<string>();
        fontsQueue = new Queue<Font>();
        if (usingAnimators) {
            for (int i = 0; i < animators.Count; i++) {
                animators[i].SetBool(animatorBoolName, true);
            }
        }
        this.textObject = textObject;
        if (cameraScript.hiddenButtons[0].activeInHierarchy) {
            cameraScript.hiddenButtons[0].GetComponent<Image>().color = textObject.bgColor;
        }
        if (cameraScript.hiddenButtons[1].activeInHierarchy) {
            cameraScript.hiddenButtons[1].GetComponent<Image>().color = textObject.bgColor;
        }
        titleText.fontSize = textObject.titleFontSize;
        titleText.color = textObject.textColor;
        titleText.font = textObject.fonts[0];
        tabletBackground.color = textObject.bgColor;
        bodyText.color = textObject.textColor;
        bodyText.fontSize = textObject.fontSize;
        bodyText.font = textObject.fonts[0];
        titleText.text = textObject.titles[0];
        for (int i = 0; i < textObject.sentences.Length; i++) {
            sentences.Enqueue(textObject.sentences[i]);
        }
        if (textObject.titles.Length > 1){
            for (int i = 0; i < textObject.titles.Length; i++) {
                titlesQueue.Enqueue(textObject.titles[i]);
            }
        }
        if (textObject.fonts.Length > 1) {
            for (int i = 0; i < textObject.fonts.Length; i++) {
                fontsQueue.Enqueue(textObject.fonts[i]);
            }
        }
        next();
    }
    public void next() {
        if (sentences.Count == 0) {
            EndText();
            return;
        }
        if (fontsQueue.Count != 0) {
            Font font = fontsQueue.Dequeue();
            bodyText.font = font;
            titleText.font = font;
        }
        if (titlesQueue.Count != 0) {
            titleText.text = titlesQueue.Dequeue();
        }
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentences.Dequeue()));
    }
    IEnumerator TypeSentence(string sentence) {
        bodyText.text = "";
        char[] _sentence_array = sentence.ToCharArray();
        for (int i = 0; i < _sentence_array.Length; i++) {
            char letter = _sentence_array[i];
            bodyText.text += letter;
            if (i%2 == 1) {
                yield return null;
            }
        }
    }
    public void EndText() {
        if (usingAnimators) {
            for (int i = 0; i < animators.Count; i++) {
                animators[i].SetBool(animatorBoolName, false);
            } 
        }
    }
}
