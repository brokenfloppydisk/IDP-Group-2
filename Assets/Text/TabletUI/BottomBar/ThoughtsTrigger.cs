using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtsTrigger : MonoBehaviour
{
    private ThoughtsManager tManager;
    [SerializeField]
    private bool hover;
    [SerializeField]
    [TextArea(2,3)]
    private string sentence;
    private void Awake() {
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
    private void OnMouseExit() {
        if (hover) {
            tManager.End();
        }
    }
}
