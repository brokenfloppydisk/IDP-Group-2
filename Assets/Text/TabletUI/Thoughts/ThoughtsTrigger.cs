using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtsTrigger : MonoBehaviour
{
    private ThoughtsManager tManager;
    [SerializeField]
    private bool hover = true;
    [SerializeField]
    [TextArea(2,3)]
    public string sentence;
    private void Start() {
        tManager = FindObjectOfType<ThoughtsManager>();
    }
    public void Trigger() {
        tManager.DisplayThoughts(sentence);
    }
    public void Trigger(string sentence) {
        tManager.DisplayThoughts(sentence);
    }

    private void OnMouseEnter() {
        if (hover) {
            Trigger();
        }
    }
}
