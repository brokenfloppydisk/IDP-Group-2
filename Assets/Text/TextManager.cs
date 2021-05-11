using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text titleText;
    public Text bodyText;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartText(TextObject textObj) {
        titleText.text = textObj.title;
        sentences.Clear();
        foreach (string sentence in textObj.sentences) {
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
        bodyText.text = sentence;
    }
    public void EndText() {
        Debug.Log("End of Text");
    }
}
