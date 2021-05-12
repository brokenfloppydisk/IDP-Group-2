using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text titleText;
    public Text bodyText;


    public List<Animator> animators;

    // Start is called before the first frame update
    void Start() {
        sentences = new Queue<string>();
    }
    public void StartText(TextObject textObj) {
        for (int i = 0; i < animators.Count; i++) {
            animators[i].SetBool("TabletOpen", true);
        }
        titleText.text = textObj.title;
        sentences.Clear();
        for (int i = 0; i < textObj.sentences.Length; i++) {
            string sentence = textObj.sentences[i];
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndText();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        bodyText.text = "";
        char[] sentence_array = sentence.ToCharArray();
        for (int i = 0; i < sentence_array.Length; i++) {
            char letter = sentence_array[i];
            bodyText.text += letter;
            yield return null;
        }
    }

    public void EndText() {
        for (int i = 0; i < animators.Count; i++) {
            animators[i].SetBool("TabletOpen", false);
        }
    }
}
