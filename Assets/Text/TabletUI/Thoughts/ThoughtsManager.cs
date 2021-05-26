﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 0649
public class ThoughtsManager : MonoBehaviour
{
    [SerializeField]
    private int charsPerFrame;
    [SerializeField]
    private Text thoughtsText;
    [SerializeField]
    private int fadeSpeed;
    [SerializeField]
    private int fadeSeconds;
    private Color thoughtsColor;
    public GameObject thoughts;
    private void Awake() {
        thoughtsColor = thoughtsText.color;
    }
    public void DisplayThoughts(string thought) {
        StopAllCoroutines();
        thoughtsText.text = "";
        thoughtsText.color = thoughtsColor;
        StartCoroutine(TypeThoughts(thought));
    }
    public void End() {
        StopAllCoroutines();
        thoughtsText.text = "";
        thoughtsText.color = thoughtsColor;
    }
    IEnumerator FadeThoughts() {
        yield return new WaitForSeconds(15);
        for (float i=1; i>=0; i-=1/fadeSpeed) {
            Color _color = thoughtsText.color;
            _color.a = i;
            thoughtsText.color = _color;
            yield return new WaitForSeconds(fadeSeconds/fadeSpeed);
        }
        End();
    }
    IEnumerator TypeThoughts(string thought) {
        thoughtsText.text = "";
        char[] _thoughts_array = thought.ToCharArray();
        for (int i = 0; i < _thoughts_array.Length; i++) {
            char letter = _thoughts_array[i];
            thoughtsText.text += letter;
            if (i % charsPerFrame == 1) {
                yield return null;
            }
        }
        StartCoroutine(FadeThoughts());
    }
}
